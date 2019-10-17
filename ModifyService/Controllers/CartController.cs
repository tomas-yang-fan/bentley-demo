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

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }
        public string info()
        {
            return "test";
        }

        [HttpPost]
        public string add(Item item)
        {
            CartBus cartbus = new CartBus();
            cartbus.AddItemToCart(item);
            return "Success";
        }

       
    }
}
