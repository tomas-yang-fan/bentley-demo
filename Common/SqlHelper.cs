using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Common
{
    public class SqlHelper
    {
        public string connString = "";
        public SqlHelper(string conStr)
        {
            this.connString = conStr;
        }

        public SqlConnection conn;

        public int ExecuteNonQuery(string sql)
        {
            int a = -1;
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                a = cmd.ExecuteNonQuery();
            }
            return a;

        }

        public DataSet ExecuteQuery(string sql)
        {
            DataSet ds = new DataSet();
            using (conn = new SqlConnection(connString))
            {

                conn.Open();
                using (SqlDataAdapter adp = new SqlDataAdapter(sql, conn))
                {
                    adp.Fill(ds);
                }
            }
            return ds;

        }

        public IList<T> ExecuteQueryList<T>(string sql)
        {
            DataSet ds = new DataSet();
            using (conn = new SqlConnection(connString))
            {

                conn.Open();
                using (SqlDataAdapter adp = new SqlDataAdapter(sql, conn))
                {
                    adp.Fill(ds);
                }
            }
            return DataSetToList<T>(ds, 0);

        }


        private IList<T> DataSetToList<T>(DataSet dataSet, int tableIndex)
        {
            if (dataSet == null || dataSet.Tables.Count <= 0 || tableIndex < 0)
            {
                return null; 
            }
            DataTable dt = dataSet.Tables[tableIndex];
            IList<T> list = new List<T>(); 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = t.GetType().GetProperties();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    foreach (PropertyInfo info in propertyInfo)
                    {
                        if (dt.Columns[j].ColumnName.ToUpper().Equals(info.Name.ToUpper()))
                        {
                            if (dt.Rows[i][j] != DBNull.Value)
                            {
                                info.SetValue(t, dt.Rows[i][j], null);
                            }
                            else
                            {
                                info.SetValue(t, null, null);
                            }
                            break;
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }

    }
}
