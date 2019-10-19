using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModifyService.Busines;
using ModifyService.Data;

namespace ModifyService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private ICartBus cartbus;
        public OrderController(ILogger<OrderController> logger, ICartBus cartbus)
        {
            this.cartbus = cartbus;
            _logger = logger;
        }

        [HttpPost]
        public void addToOrder()
        {
            this.cartbus.addToOrder();
          
        }
        [HttpPut]
        public void UpdataOrder(int id)
        {
            this.cartbus.UpdataOrder(id);

        }


    }
}
