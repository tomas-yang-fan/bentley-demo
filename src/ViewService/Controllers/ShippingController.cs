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
    public class ShippingController : ControllerBase
    {

        private readonly ILogger<ShippingController> _logger;
        private ICartBus cartBus;
        public ShippingController(ILogger<ShippingController> logger, ICartBus cartBus)
        {
            this.cartBus = cartBus;
            _logger = logger;
        }

        public IList<Shipping> list(string orderNumber)
        {
            return this.cartBus.GetShippingInfo(orderNumber);
            
        }
         
    }
}
