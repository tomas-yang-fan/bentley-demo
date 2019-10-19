using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.Data
{
    public class Order
    {
        public int TransactionNumber { get; set; }
        public string OrderNumber { get; set; }
        public Decimal PriceAmount { get; set; }

        public Decimal CostAmount { get; set; }

        public string Status { get; set; }

        public DateTime InDate { get; set; }

        public string InUser { get; set; }
    }
}
