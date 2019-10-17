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

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        public IList<Item> list()
        {
            CartBus cartbus = new CartBus();
            return cartbus.GetCartInfo();
           
        }

       
    }
}
