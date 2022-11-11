using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOFinal.Models;

namespace XO_CodeFirst.Model
{
    public class XOContext : DbContext
    {
        // Entities
        public DbSet<Administrator> Administrators { get; set; }
       // public DbSet<Bank> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Report> Reports { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                           Data Source=SQL8001.site4now.net;Initial Catalog=db_a8d196_xo;User Id=db_a8d196_xo_admin;Password=xo123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>().HasKey(K => new { K.CustId, K.ProdId });
            modelBuilder.Entity<Report>().HasKey(K => new { K.CustId, K.ProdId });

        }
    }
}
