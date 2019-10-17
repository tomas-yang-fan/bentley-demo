
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.Data;

namespace ViewService.Busines
{
    public class CartBus
    {
        public IList<Item> GetCartInfo()
        {
            CartDAO cartDAO = new CartDAO();
            string sql = @"
select  UserID
	   ,ItemNumber
	   ,ItemDescription
	   ,UnitPrice
	   ,Cost
	   ,Qty
	   ,InDate
	   ,InUser 
from Tomas_Cart
                            ";

            return cartDAO.GetCartInfo(sql);
        }

    }
}
