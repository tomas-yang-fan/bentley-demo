
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.Data;

namespace ViewService.Busines
{
    public interface ICartBus {
        public IList<Item> GetCartInfo();
        public IList<Order> GetOrderInfo();
        public IList<Shipping> GetShippingInfo(string orderNumber);
    }
    public class CartBus:ICartBus
    {
        private ICartDAO cartDAO;
        public CartBus(ICartDAO cartDAO)
        {
            this.cartDAO = cartDAO;
        }

        public IList<Item> GetCartInfo()
        {
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


        public IList<Order> GetOrderInfo()
        {
            string sql = @"
SELECT OrderNumber
	,PriceAmount
	,STATUS
FROM Tomas_OrderMaster
";
            return cartDAO.GetOrderInfo(sql);
        }


        public IList<Shipping> GetShippingInfo(string orderNumber)
        {
            string sql = $@"
SELECT ShippingNumber
	,TrackingNumber
	,OrderNumber
	,ShipTo
	,ShipFrom
	,STATUS
FROM Tomas_Shipping
where OrderNumber = '{orderNumber}'
";
            return cartDAO.GetShippingInfo(sql);
        }
    }
}
