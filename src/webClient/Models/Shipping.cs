using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webClient.Models
{
    public class Shipping
    {
        public string ShippingNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string OrderNumber { get; set; }

        public string ShipTo { get; set; }

        public string ShipFrom { get; set; }

        public string Status { get; set; }

    }
}
