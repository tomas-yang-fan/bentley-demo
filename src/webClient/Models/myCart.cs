using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webClient.Models
{
    public class MyCart
    {
        public IList<Item> items { get; set; }
        public decimal PriceAmount
        {
            get
            {
                if (items.Any())
                {
                    return items.Sum(r => r.Qty * r.UnitPrice);
                }
                else
                {
                    return 0;
                }
                
            }
        }
    }
}
