using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.Data
{
    public class Item
    {
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public decimal UnitPrice { get; set; }
        
        public decimal Cost { get; set; }
        
        public int Qty { get; set; }
        public string Status { get; set; }
    }
}
