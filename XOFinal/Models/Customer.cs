using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOFinal.Models;

namespace XO_CodeFirst.Model
{
    public partial class Customer
    {
        //???????????Binifet
        public Customer()
        {
            Bills = new HashSet<Bill>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CustName { get; set; }
        public DateTime? DateOfSignUp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        //public int? CardNumber { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
       public virtual ICollection<Favorite> Favorites { get; set; }
    }

    public class AddUpdateCust
    {
        
        public string CustName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
    public class LoginCustomer
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class GetCustomer
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

    }
}
