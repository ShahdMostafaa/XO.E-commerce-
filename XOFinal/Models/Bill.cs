using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XO_CodeFirst.Model
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int? CustId { get; set; }
        public DateTime? DateOfBill { get; set; }
        public string ProdTitle { get; set; }
        public decimal? Tax { get; set; }
        public int? CardNumber { get; set; }
        public int? ProdId { get; set; }

       // public virtual Bank CardNumberNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual Product Prod { get; set; }
    }
}
