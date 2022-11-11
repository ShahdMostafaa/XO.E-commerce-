using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XOFinal.Models
{
    public class Report
    {
        public int? ProdId { get; set; }
        public int? CustId { get; set; }

        public Customer Cust { get; set; }
        public Product Prod { get; set; }
    }

    public class ReportOperate
    {
        public int? ProdId { get; set; }
        public int? CustId { get; set; }
    }
}
