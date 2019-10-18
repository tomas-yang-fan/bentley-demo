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
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private ICartBus cartBus;
        public OrderController(ILogger<OrderController> logger, ICartBus cartBus)
        {
            this.cartBus = cartBus;
            _logger = logger;
        }

        public IList<Order> list()
        {
            return cartBus.GetOrderInfo();
        }


    }
}
