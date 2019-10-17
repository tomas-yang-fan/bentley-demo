using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webClient.Busines;
using webClient.Models;

namespace webClient.Controllers
{
    public class WebClientController : Controller
    {

        // 
        // GET: /HelloWorld/

        public IActionResult Buy()
        {
            //ViewData["Message"] = "buy something";
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Item item)
        {
            MyClientBus myclient = new MyClientBus();
            
            myclient.addToMyCart(item);
            //ViewData["Message"] = "buy something successfully!";
            return View(new Item());
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public async Task<IActionResult> MyCart()
        {
            MyCart mycart = new MyCart();
            //List<Item> items = new List<Item>();
            //var item1 = new Item();
            //item1.ItemDescription = "notebook";
            //item1.Qty = 3;
            //item1.UnitPrice = 4;

            //var item2 = new Item();
            //item2.ItemDescription = "computers";
            //item2.Qty = 1;
            //item2.UnitPrice = 10;
            //items.Add(item1);
            //items.Add(item2);
            //mycart.items = items;
            MyClientBus myclient = new MyClientBus();
            mycart.items = await myclient.GetCartList();
            return View(mycart);
        }

        [HttpPost]
        public IActionResult MyCart(List<Item> items)
        {
            return View(new MyCart());
        }

        public IActionResult Orders()
        {
            List<Order> orders = new List<Order>();
            Order order = new Order();
            List<Item> items = new List<Item>();
            var item1 = new Item();
            item1.ItemDescription = "notebook";
            item1.Qty = 3;
            item1.UnitPrice = 4;

            var item2 = new Item();
            item2.ItemDescription = "computers";
            item2.Qty = 1;
            item2.UnitPrice = 10;
            items.Add(item1);
            items.Add(item2);
            order.Items = items;
            order.OrderNumber = Guid.NewGuid().ToString();
            order.CreateDate = DateTime.Now.ToString();
            orders.Add(order);
            return  View(orders);
        }


        public IActionResult Shipping()
        {
           
            Shipping shipping = new Shipping();
            List<Item> items = new List<Item>();
            var item1 = new Item();
            item1.ItemDescription = "notebook";
            item1.Qty = 3;
            item1.UnitPrice = 4;

            var item2 = new Item();
            item2.ItemDescription = "computers";
            item2.Qty = 1;
            item2.UnitPrice = 10;
            items.Add(item1);
            items.Add(item2);
            shipping.Items = items;
            shipping.OrderNumber = Guid.NewGuid().ToString();
            //shipping.TrackingNumber = Guid.NewGuid().ToString();
            shipping.IsShipped = "No";
            shipping.ShipCharge = 0.1m;
            return View(shipping);
        }
        public IActionResult CommingSoon(List<Item> items)
        {
            return View();
        }

    }
}