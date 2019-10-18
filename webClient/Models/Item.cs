using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webClient.Models
{
    public class Item
    {
        private string itemNumber;
        public string ItemNumber { get {
                if (string.IsNullOrEmpty(itemNumber))
                {
                    itemNumber = DateTime.Now.ToString("yyMMddhhmmss");
                }
                
                return itemNumber;
            } set {
                itemNumber = value;
            }
        }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }

        private decimal cost = 1m;
        public decimal Cost {
            get {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        private decimal unitPrice = 2m;
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }
    }
}
