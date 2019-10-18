using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModifyService.Busines;
using ModifyService.Data;

namespace ModifyService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartController : ControllerBase
    {

        private readonly ILogger<CartController> _logger;

        private ICartBus cartbus;
        public CartController(ILogger<CartController> logger,ICartBus cartbus)
        {
            this.cartbus = cartbus;
            _logger = logger;
        }
        public string info()
        {
            return "test";
        }

        [HttpPost]
        public int add(Item item)
        {
            return this.cartbus.AddItemToCart(item);
        }

        [HttpPost]
        public int delete(string itemNumber)
        {
            return this.cartbus.DeleteCartItem(itemNumber);
            
        }


    }
}
