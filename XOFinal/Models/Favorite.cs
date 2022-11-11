using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XOFinal.Models
{
    public class Favorite
    {
        public int? ProdId { get; set; }
        public int? CustId { get; set; }

        public Customer  Cust{ get; set; }
        public Product Prod { get; set; }
    }
    public class FavOperate
    {
        public int ProdId { get; set; }
        public int CustId { get; set; }
    }

    
}
