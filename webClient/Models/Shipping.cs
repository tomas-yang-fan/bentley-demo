using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webClient.Models
{
    public class Shipping
    {
        public string TrackingNumber { get; set; }
        public string OrderNumber { get; set; }
        public decimal AmountPrices { get; set; }

        public decimal ShipCharge { get; set; }

        public string IsShipped { get; set; }

        public string From { get; set; }

        public string To { get; set; }
        public List<Item> Items { get; set; }
    }
}
