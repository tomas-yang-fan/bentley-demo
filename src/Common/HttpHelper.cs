using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
   
        public static class HttpAPIClient
        {
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="url"></param>
            /// <param name="headers"></param>
            /// <param name="method"></param>
            /// <param name="requestBody"></param>
            /// <param name="proxy"></param>
            /// <returns></returns>
            public static async Task<string> GetResponse(string url, Dictionary<string, string> headers, string method = "GET", string requestBody = "",  bool isRecordLog = true)
            {
                //var logEntity = new LogEntity();
                var request = CreateRequest(url, method, headers);
                string responseContent;
                try
                {
                    if (method.ToUpper().Equals("PUT") || method.ToUpper().Equals("POST") || method.ToUpper().Equals("DELETE"))
                    {
                        //logEntity.RequestBody = requestBody;
                        byte[] data = Encoding.Unicode.GetBytes(requestBody.Trim());
                        using (Stream stream = await request.GetRequestStreamAsync())
                        {
                            using (StreamWriter myStreamWriter = new StreamWriter(stream, Encoding.Default))
                            { await myStreamWriter.WriteAsync(requestBody); }
                        }
                    }
                    using (var response = await request.GetResponseAsync() as HttpWebResponse)
                    {
                        if (method.ToUpper().Equals("HEAD"))
                        {
                            responseContent = response.Headers.ToString();
                        }
                        else
                        {
                            if (null == response) throw new Exception("Unexpected null response.");
                            responseContent = BuildResponseContent(response);
                        }
                    }
                    //logEntity.ResponseCode = 200;
                    //logEntity.ResponseBody = responseContent;
                }
                catch (WebException webex)
                {
                    //logEntity.ResponseCode = 500;
                    //logEntity.ResponseBody = webex.ToString();
                    throw new Exception(GetWebExceptionResponseContent(webex));
                }
                catch (Exception ex)
                {
                    //logEntity.ResponseCode = 500;
                    //logEntity.ResponseBody = ex.ToString();
                    throw ex;
                }
                finally
                {
                    if (isRecordLog)
                    {
                        //logEntity.RequestHeaders = GetRequestHeaders(headers);
                        //logEntity.RequestURL = url;
                        //logEntity.RequestTime = DateTime.UtcNow;
                        //logEntity.RequestIP = headers.ContainsKey("x-source-ip") ? headers["x-source-ip"] : Environment.MachineName;
                        //logEntity.ResponseTime = DateTime.UtcNow;
                        //LogDAO.RecordLog(logEntity);
                    }
                }

                return responseContent;
            }

            //public static List<Header> GetRequestHeaders(IDictionary<string, string> headers)
            //{
            //    var headerList = new List<Header>();

            //    foreach (var item in headers)
            //    {
            //        Header header = new Header();
            //        header.Name = item.Key;
            //        header.Value = item.Value;
            //        headerList.Add(header);
            //    }
            //    return headerList;

            //}
            public static T DeserializeXmlToObject<T>(string xml)
            {
                T myObject;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(xml))
                {
                    myObject = (T)serializer.Deserialize(reader);
                }
                return myObject;
            }

            #region Private Method
            private static string GetWebExceptionResponseContent(WebException wex)
            {
                using (var response = wex.Response)
                {
                    if (null == response) throw wex;

                    return BuildErrorContent((HttpWebResponse)response);
                }
            }

            private static WebRequest CreateRequest(string url, string method, Dictionary<string, string> headers)
            {
                if (headers == null)
                {
                    headers = new Dictionary<string, string>();
                }
                if (!headers.ContainsKey("Content-Type"))
                    headers.Add("Content-Type", "application/json");
                if (!headers.ContainsKey("Accept"))
                    headers.Add("Accept", "application/json");

                if (!headers.ContainsKey("CacheControl"))
                {
                    headers.Add("pragma", "no-cache");
                    headers.Add("CacheControl", "no-cache, must-revalidate");
                }

                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                    var request = WebRequest.Create(url) as HttpWebRequest;

                    //if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    ServicePointManager.ServerCertificateValidationCallback =
                    //        (obj, certificate, chain, errors) => { return true; };
                    //    request.KeepAlive = true;
                    //}




                    if (null == request) throw new Exception("Unexpected null request.");

                    request.Method = method;

                    //if (proxy != null && proxy.ProxyEnable)
                    //{
                    //    var webProxy = new WebProxy(proxy.ProxyAddress, proxy.ProxyPort);
                    //    webProxy.Credentials = new NetworkCredential(proxy.ProxyUser, proxy.ProxyPassword, proxy.ProxyDomain);
                    //    request.Proxy = webProxy;
                    //}

                    foreach (var keyValuePair in headers ?? new Dictionary<string, string>())
                    {
                        if (keyValuePair.Key.ToLower().Equals("accept"))
                        {
                            request.Accept = keyValuePair.Value;
                            continue;
                        }
                        if (keyValuePair.Key.ToLower().Replace("-", string.Empty).Equals("contenttype"))
                        {
                            request.ContentType = keyValuePair.Value;
                            continue;
                        }

                        if (!string.IsNullOrEmpty(keyValuePair.Value))
                        {
                            request.Headers[keyValuePair.Key] = keyValuePair.Value;
                        }
                    }
                    return request;
                }
                catch (Exception ex)
                {

                    return null;
                }

            }

            private static string BuildErrorContent(HttpWebResponse response)
            {
                var responseContent = new StringBuilder();

                var httpResponse = response;
                responseContent.AppendFormat("HTTP Status Code: {0} {1}{2}",
                                        GetHttpStatusCodeValue(httpResponse.StatusCode),
                                        httpResponse.StatusCode,
                                        Environment.NewLine);

                if (!string.IsNullOrWhiteSpace(httpResponse.ContentType))
                {
                    responseContent.AppendFormat("Content-Type: {0}{1}",
                                                      httpResponse.ContentType,
                                                      Environment.NewLine);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (null == responseStream) return responseContent.ToString();
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        try
                        {
                            //if 407 , there will throw exception ,
                            //"Unable to read data from the transport connection. The connection was closed before all data could be read"
                            responseContent.Append(streamReader.ReadToEnd());
                        }
                        catch (Exception)
                        {
                        }

                    }
                }

                return responseContent.ToString();
            }

            private static int GetHttpStatusCodeValue(HttpStatusCode code)
            {
                return (int)code;
            }

            private static string BuildResponseContent(WebResponse response)
            {
                var responseContent = new StringBuilder();

                using (var responseStream = response.GetResponseStream())
                {
                    if (null == responseStream) return responseContent.ToString();
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        responseContent.Append(streamReader.ReadToEnd());
                    }
                }

                return responseContent.ToString();
            }

            #endregion
        }
    
}
