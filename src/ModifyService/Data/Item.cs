using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyService.Data
{
    public class Item
    {
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public decimal UnitPrice { get {
                return 1.99m;
            } }
        public decimal Cost
        {
            get
            {
                return 0.99m;
            }
        }
        public int Qty { get; set; }
        public string Status { get; set; }
   
    }
}
