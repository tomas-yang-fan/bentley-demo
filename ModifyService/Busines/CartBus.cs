using ModifyService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyService.Busines
{
    public class CartBus
    {
        public void AddItemToCart(Item item)
        {
            CartDAO cartDAO = new CartDAO();
            string sql = @"INSERT INTO Tomas_Cart (
                                            UserID
	                                        ,ItemNumber
	                                        ,ItemDescription
	                                        ,UnitPrice
	                                        ,Cost
	                                        ,Qty
	                                        ,InDate
	                                        ,InUser
	                                        )
                                        VALUES(
                                            'tomas'
                                            , '@ItemNumber'
                                            , '@ItemDescription'
                                            , @UnitPrice
                                            , @Cost
                                            , @Qty
                                            , '@InDate'
                                            , '@InUser'
                                            )
                            ";

            sql = sql.Replace("@ItemNumber", item.ItemNumber)
               .Replace("@ItemDescription", item.ItemDescription)
               .Replace("@UnitPrice", item.UnitPrice+"")
               .Replace("@Cost", item.Cost+"")
               .Replace("@Qty", item.Qty+"")
               .Replace("@InDate", DateTime.Now.ToString("yyyy-MM-dd"))
                .Replace("@InUser","Tomas yang");
            cartDAO.AddItemToCart(sql);
        }

    }
}
