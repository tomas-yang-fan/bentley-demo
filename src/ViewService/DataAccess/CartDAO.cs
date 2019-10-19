using Common;
using ViewService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ViewService.Busines
{
    public interface ICartDAO {
        public IList<Item> GetCartInfo(string sql);
        public IList<Order> GetOrderInfo(string sql);

        public IList<Shipping> GetShippingInfo(string sql);
    }
    public class CartDAO:ICartDAO
    {
        public SqlHelper sqlhelper;

        public CartDAO(IOptions<ApplicationSettings> applicationSettings)
        {
            var sqlConString = applicationSettings.Value.SqlConString;
            sqlhelper = new SqlHelper(sqlConString);
        }
        public IList<Item> GetCartInfo(string sql)
        {
            return sqlhelper.ExecuteQueryList<Item>(sql);
        }
        public IList<Order> GetOrderInfo(string sql)
        {
            return sqlhelper.ExecuteQueryList<Order>(sql);
        }
        public IList<Shipping> GetShippingInfo(string sql)
        {
            return sqlhelper.ExecuteQueryList<Shipping>(sql);
        }

    }
}
