using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webClient.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public decimal AmountPrices {
            get
            {
                if (Items.Any())
                {
                    return Items.Sum(r => r.Qty * r.UnitPrice);
                }
                else
                {
                    return 0;
                }

            }
        }

        public string CreateDate { get; set; }
        public List<Item> Items { get; set; }
    }
}
