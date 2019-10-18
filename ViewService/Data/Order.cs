using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.Data
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public Decimal PriceAmount { get; set; }

        public string Status { get; set; }
    }
}
