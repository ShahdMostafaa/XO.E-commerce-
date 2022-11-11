using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOFinal.Models;

namespace XO_CodeFirst.Model
{
    public partial class Product
    {
        public Product()
        {
            Pictures = new HashSet<Picture>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public int? CustId { get; set; }
        public string Description { get; set; }
        public int? CatId { get; set; }
        public decimal? Price { get; set; }
        public bool? Negotiable { get; set; }
        public string Location { get; set; }

        public virtual Category Cat { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
    public class GetProduct
    {
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        public string CustName { get; set; }
        public string CustPhoto { get; set; }
        public virtual ICollection<string> Pictures { get; set; }
    }
    public class GetOneProduct
    {
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string CustName { get; set; }
        public string CustPhoto { get; set; }
        public virtual ICollection<string> Pictures { get; set; }
        
    }
}
