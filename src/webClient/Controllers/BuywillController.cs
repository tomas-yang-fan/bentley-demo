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
    public class BuywillController : Controller
    {

        private IMyClientBus myClientBus;
        public BuywillController(IMyClientBus myClientBus)
        {
            this.myClientBus = myClientBus;
        }

        public IActionResult Buy()
        {
            //ViewData["Message"] = "buy something";
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Item item)
        {

            myClientBus.AddToMyCart(item);
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

            mycart.items = await myClientBus.GetCartList();
            return View(mycart);
        }

        [HttpPost]
        public IActionResult MyCart(List<Item> items)
        {
            return View(new MyCart());
        }


        public IActionResult Delete(string id)
        {
            myClientBus.DeleteCartItem(id);
            return RedirectToAction("MyCart");

        }

        public async Task<IActionResult> Orders()
        {
            IList<Order> orders = new List<Order>();
            //Order order = new Order();
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
            //order.Items = items;
            //order.OrderNumber = Guid.NewGuid().ToString();
            //order.CreateDate = DateTime.Now.ToString();
            //orders.Add(order);
            orders = await this.myClientBus.GetOrderList();
            return View(orders);
        }

        [HttpPost]
        public IActionResult Pay()
        {
            this.myClientBus.AddToOrders();
            return RedirectToAction("Orders");
        }

        public async Task<IActionResult> Shipping(string id)
        {

            IList<Shipping> shippingList = new List<Shipping>();
            var shipping = new Shipping();
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
            //shipping.OrderNumber = Guid.NewGuid().ToString();
            shippingList = await this.myClientBus.GetShippingList(id);
            if (shippingList.Count > 0)
            {
                shipping = shippingList[0];
            }
            
            return View(shipping);
        }
        public IActionResult CommingSoon(List<Item> items)
        {
            return View();
        }

    }
}