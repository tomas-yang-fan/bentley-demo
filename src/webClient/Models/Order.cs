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

        public decimal PriceAmount { get; set; }
       
        public string CreateDate { get; set; }
        public List<Item> Items { get; set; }
    }
}
