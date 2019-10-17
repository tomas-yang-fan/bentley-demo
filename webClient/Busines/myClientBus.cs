using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using webClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace webClient.Busines
{
    public class MyClientBus
    {
        public MyClientBus()
        {

        }
        public async void addToMyCart(Item item) {
            var requireBody = JsonConvert.SerializeObject(item);
           await HttpAPIClient.GetResponse("http://localhost:38456/cart/add", null, "POST", requireBody);
        }

        public async Task<IList<Item>> GetCartList()
        {
           var response =  await HttpAPIClient.GetResponse("http://localhost:34531/cart/list", null);
            return JsonConvert.DeserializeObject<List<Item>>(response);

        }
    }
}
