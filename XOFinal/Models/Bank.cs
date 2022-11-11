//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace XO_CodeFirst.Model
//{
//    public partial class Bank
//    {
//        public Bank()
//        {
//            Bills = new HashSet<Bill>();
//        }
//        [Key]
//        public int AccountId { get; set; }
//        public string CustName { get; set; }
//        public int CardNumber { get; set; }
//        public decimal Invoice { get; set; }

//        public virtual ICollection<Bill> Bills { get; set; }
//    }
//}
