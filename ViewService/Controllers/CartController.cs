using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewService.Busines;
using ViewService.Data;

namespace ViewService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartController : ControllerBase
    {

        private readonly ILogger<CartController> _logger;

        private ICartBus cartBus;

        public CartController(ILogger<CartController> logger,ICartBus cartBus)
        {
            this.cartBus = cartBus;
            _logger = logger;
        }

        public IList<Item> list()
        {
            var dd =cartBus.GetCartInfo();
            return dd;


        }

       
    }
}
