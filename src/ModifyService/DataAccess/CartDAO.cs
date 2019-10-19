using Common;
using Microsoft.Extensions.Options;
using ModifyService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyService.Busines
{
    public interface ICartDAO {
        public int AddItemToCart(string sql);
        public int DeleteCartItem(string sql);

        public int addToOrder(string sql);
        public int UpdataOrder(string sql);
    }
    public class CartDAO:ICartDAO
    {
        public SqlHelper sqlhelper;

        public CartDAO(IOptions<ApplicationSettings> applicationSettings)
        {
            var sqlConString = applicationSettings.Value.SqlConString;
            sqlhelper = new SqlHelper(sqlConString);
        }
        public int AddItemToCart(string sql)
        {
            return sqlhelper.ExecuteNonQuery(sql);
        }
        public int UpdataOrder(string sql)
        {
            return sqlhelper.ExecuteNonQuery(sql);
        }
        public int DeleteCartItem(string sql)
        {
            return sqlhelper.ExecuteNonQuery(sql);
        }
        public int addToOrder(string sql)
        {
            return sqlhelper.ExecuteNonQuery(sql);
        }
        


    }
}
