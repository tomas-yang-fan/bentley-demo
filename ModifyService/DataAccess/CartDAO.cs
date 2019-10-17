using Common;
using ModifyService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModifyService.Busines
{
    public class CartDAO
    {
        public SqlHelper sqlhelper;

        public CartDAO()
        {
            sqlhelper = new SqlHelper();
        }
        public void AddItemToCart(string sql)
        {
            sqlhelper.ExecuteNonQuery(sql);
        }


    }
}
