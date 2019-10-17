using Common;
using ViewService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.Busines
{
    public class CartDAO
    {
        public SqlHelper sqlhelper;

        public CartDAO()
        {
            sqlhelper = new SqlHelper();
        }
        public IList<Item> GetCartInfo(string sql)
        {
            return sqlhelper.ExecuteQueryList<Item>(sql);
        }


    }
}
