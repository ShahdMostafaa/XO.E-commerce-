using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XO_CodeFirst.Controller
{
    [ApiController]
    [Route("Adimnistrator")]
    public class AdministratorController : ControllerBase
    {
        XOContext _Context;
        public AdministratorController(XOContext context)
        {
            _Context = context;
        }

        // return ??????????????????????????????????????? front  ???
        [HttpPost("Login")]
        public ActionResult LogIn(LoginAdmin Admin)
        {
            var Account = _Context.Administrators.Where(account => account.Email == Admin.Email && account.AdminPass == Admin.AdminPass);
            if (Account == null)
            {
                return BadRequest("No");
            }
            return Ok(Account);
        }


        //[HttpPost("AddCategory")]
        //public ActionResult Add(NewCategory NewCat)
        //{
        //    var check = _Context.Categories.Any(cat => cat.Name == NewCat.Name);
        //    if (!(check))
        //    {
        //        Category NewOne = new Category()
        //        {
        //            Name = NewCat.Name
        //        };
        //        _Context.Categories.Add(NewOne);
        //        _Context.SaveChanges();
        //        return Ok("done");
        //    }
        //    else
        //        return BadRequest("No");
        //}


        ////update Category
        //[HttpPut("UpdateCategory")]
        //public ActionResult Update(int CatId , string NewName)
        //{
        //    var category = _Context.Categories.Where(cat => cat.CategoryId == CatId).FirstOrDefault();
        //    //Check????
        //    category.Name = NewName;
        //    return Ok("Done");
        //}


        //select Email


        [HttpGet("GetAllCustomer")]
        public ActionResult All()
        {
            List<GetCustomer> Customers = new List<GetCustomer>();
            var AllCustomers = _Context.Customers.AsNoTracking().ToList();
            foreach (var item in AllCustomers)
            {
                GetCustomer customer = new GetCustomer()
                {
                    CustName = item.CustName,
                    Email = item.Email,
                    Phone = item.Phone
                };
                Customers.Add(customer);
            }
            return Ok(Customers);
        }


        [HttpGet("GetMostFavoriteProducts")]
        public ActionResult FavProducts()
        {
              
            var FavList = _Context.Favorites.ToList();
            foreach (var item in FavList)
            {
                var GetProd = _Context.Products.Where(prod => prod.ProductId == item.ProdId).FirstOrDefault();

            }
        }



        [HttpGet("ProfitForOneDay")]
        public ActionResult DayProfit(DateTime date )
        {
            var Bills = _Context.Bills.Where(b => b.DateOfBill == date).Count();
            double Profit = Bills * 150;
            return Ok(Profit); 
        }

        [HttpGet("ProfitForAPeriodOfTime")]
        public ActionResult ProfitOfPeriodOfTime (DateTime Start , DateTime End)
        {
            var Bills = _Context.Bills.ToList().Count();
        }
        
        //[HttpGet("ProfitForSpesificYear")]


        //[HttpGet("Most Products Have Report")]
        //[HttpGet("Catagories Have Most Product's Favourite ")]
        //[HttpGet("GetAllBill")]
        //[HttpGet("GetAllAdmin")]
        //[HttpGet("GetAllProduct")]
        //[HttpGet("CustomerOfMostReport")]

    }
}
