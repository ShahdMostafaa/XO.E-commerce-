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
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        XOContext _Context;
        public CustomerController(XOContext context)
        {
            _Context = context;
        }


        [HttpPost("Login")]
        public ActionResult LogIn(LoginCustomer customer)
        {
            var Account = _Context.Customers.Where(account => account.Email == customer.Email && account.Password == customer.Password).FirstOrDefault();
            if (Account == null)
            {
                return BadRequest("No");
            }
            GetCustomer cust = new GetCustomer()
            {
                Id = Account.Id,
                CustName = Account.CustName,
                Email = Account.Email,
                Phone = Account.Phone,
                Description = Account.Description,
                Photo = Account.Photo
            };
            return Ok(Account);
        }


        //Add Photo code
        [HttpPost("AddNewAccount")]
        public ActionResult Add(AddUpdateCust customer)
        {
            var checkemail = _Context.Customers.AsNoTracking().Any(cus => cus.Email == customer.Email);
            if (!(checkemail))
            {
                Customer NewCust = new Customer()
                {
                    CustName = customer.CustName,
                    Email = customer.Email,
                    Password = customer.Password,
                    Photo = customer.Photo
                };
                _Context.Customers.Add(NewCust);
                _Context.SaveChanges();
                return Ok("done");
            }
            else
                return BadRequest("No");

        }


        [HttpDelete("DeleteAccount")]
        public ActionResult Remove([FromForm] int Id)
        {
            ////////////// ???????????????????????????? 
            var CustProds = _Context.Products.Where(cus => cus.CustId == Id).ToList();
            foreach (var item in CustProds)
            {
                var ProdBill = _Context.Bills.Where(bill => bill.ProdId == item.ProductId).FirstOrDefault();
                _Context.Bills.Remove(ProdBill);

                var ProdPic = _Context.Pictures.Where(pic => pic.ProdId == item.ProductId);
                foreach (var pic in ProdPic)
                {
                    _Context.Pictures.Remove(pic);
                }
                _Context.Products.Remove(item);

            }

            var Exist = _Context.Customers.Find(Id);
            if (Exist != null)
            {
                _Context.Customers.Remove(Exist);
                _Context.SaveChanges();
                return Ok("Done");
            }
            else
                return BadRequest("No");
        }


        [HttpPut("UpdateCustomer")]
        public ActionResult Update([FromQuery] int Id, [FromBody] AddUpdateCust ChangeCust)
        {
            var FindAccount = _Context.Customers.AsNoTracking().Where(cus => cus.Id == Id).FirstOrDefault();
            if (FindAccount == null)
            {
                return BadRequest("No");
            }

            Customer UpdatedCust = new Customer()
            {
                Id = Id,
                CustName = ChangeCust.CustName ?? FindAccount.CustName,
                Phone = ChangeCust.Phone ?? FindAccount.Phone,
                Description = ChangeCust.Description ?? FindAccount.Description,
                Password = ChangeCust.Password ?? FindAccount.Password,
                Photo = ChangeCust.Photo ?? FindAccount.Photo,
                Email = ChangeCust.Email ?? FindAccount.Email
            };

            if (ChangeCust.Email != FindAccount.Email)
            {
                var CheckEmail = _Context.Customers.AsNoTracking().Where(cus => cus.Email == ChangeCust.Email);
                if (CheckEmail == null)
                {
                    _Context.Customers.Update(UpdatedCust);
                    _Context.SaveChanges();
                    return Ok(UpdatedCust);
                }
                else
                    return BadRequest("NO");
            }
            else
            {
                _Context.Customers.Update(UpdatedCust);
                _Context.SaveChanges();
                return Ok(UpdatedCust);
            }
            return Unauthorized("Bad");
        }
    }
}








