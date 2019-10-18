using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinFormClient.Data
{
    public class Order
    {
        public int TransactionNumber { get; set; }

        public string OrderNumber { get; set; }

        public string Status { get; set; }
        public Decimal CostAmount { get; set; }
        public Decimal PriceAmount { get; set; }

        public string InDate { get; set; }

        public string InUser { get; set; }
    }
}
