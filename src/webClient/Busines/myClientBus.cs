using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using webClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;

namespace webClient.Busines
{
    public interface IMyClientBus
    {
        public void AddToMyCart(Item item);
        public Task<IList<Item>> GetCartList();

        public void DeleteCartItem(string ItemNumber);

        public void AddToOrders();

        public Task<IList<Order>> GetOrderList();

        public Task<IList<Shipping>> GetShippingList(string orderNumber);
    }
    public class MyClientBus: IMyClientBus
    {
        private string AddToMyCartUrl;
        private string GetCartListUrl;
        private string DeleteCartItemUrl;
        private string AddToOrdersUrl;
        private string GetOrderListUrl;
        private string GetShippingListUrl;

        public MyClientBus(IOptions<ApplicationSettings> applicationSettings)
        {
            AddToMyCartUrl = applicationSettings.Value.AddToMyCartUrl;
            GetCartListUrl = applicationSettings.Value.GetCartListUrl;
            DeleteCartItemUrl = applicationSettings.Value.DeleteCartItemUrl;
            AddToOrdersUrl = applicationSettings.Value.AddToOrdersUrl;
            GetOrderListUrl = applicationSettings.Value.GetOrderListUrl;
            GetShippingListUrl = applicationSettings.Value.GetShippingListUrl;

        }
        public async void AddToMyCart(Item item) {
            var requireBody = JsonConvert.SerializeObject(item);
           await HttpAPIClient.GetResponse(AddToMyCartUrl, null, "POST", requireBody);
        }

        public async Task<IList<Item>> GetCartList()
        {
           var response =  await HttpAPIClient.GetResponse(GetCartListUrl, null);
            return JsonConvert.DeserializeObject<List<Item>>(response);

        }

        public async void DeleteCartItem(string ItemNumber)
        {
            await HttpAPIClient.GetResponse($"{DeleteCartItemUrl}?itemNumber={ItemNumber}", null,"DELETE");
        }

        public async void AddToOrders()
        {
            await HttpAPIClient.GetResponse(AddToOrdersUrl, null, "POST");
        }

        public async Task<IList<Order>> GetOrderList()
        {
            var response = await HttpAPIClient.GetResponse(GetOrderListUrl, null);
            return JsonConvert.DeserializeObject<List<Order>>(response);

        }

        public async Task<IList<Shipping>> GetShippingList(string orderNumber)
        {
            var response = await HttpAPIClient.GetResponse($"{GetShippingListUrl}?orderNumber={orderNumber}", null);
            return JsonConvert.DeserializeObject<List<Shipping>>(response);

        }
    }
}
