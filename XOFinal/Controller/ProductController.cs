using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XO_CodeFirst.Controller
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        XOContext _Context;
        public ProductController(XOContext context)
        {
            _Context = context;
        }


        [HttpGet("GetAllProduct")]
        public ActionResult AllProduct(int PageNum)
        {
            int StartRang = 1*(PageNum*10);
            int EndRang = 20 * (PageNum * 10);
            var MainProduct = _Context.Products.ToList().GetRange(StartRang , EndRang);
            int PagesNum = (int)Math.Ceiling((decimal)(MainProduct.Count() / 20));
            List<GetProduct> Products = new List<GetProduct>();
            foreach (var product in MainProduct)
            {
                var Customer = _Context.Customers.Where(cus => cus.Id == product.CustId).FirstOrDefault();
                var Picture = _Context.Pictures.Where(pic => pic.ProdId == product.ProductId).Select(pic => pic.Photo).ToList();
                GetProduct prod = new GetProduct()
                {
                    Title = product.Title,
                    CustName = Customer.CustName,
                    CustPhoto = Customer.Photo,
                    Pictures = Picture,
                    Price = product.Price
                };
                Products.Add(prod);
            }
            return Ok(Products); ///// return PagesNum


            /*int PagesNum = (int)Math.Ceiling((decimal)(MainProduct.Count() / 20)); ///////////////////////////
            Dictionary<int, List<GetProduct>> Pages = new Dictionary<int, List<GetProduct>>();
            for (int i =0; i < PagesNum; i++)
            {
                List<GetProduct> Products = new List<GetProduct>();
                foreach (var product in MainProduct)
                {
                    var Customer = _Context.Customers.Where(cus => cus.Id == product.CustId).FirstOrDefault();
                    var Picture = _Context.Pictures.Where(pic => pic.ProdId == product.ProductId).Select(pic => pic.Photo).ToList();
                    GetProduct prod = new GetProduct()
                    {
                        Title = product.Title,
                        CustName = Customer.CustName,
                        CustPhoto = Customer.Photo,
                        Pictures = Picture,
                        Price = product.Price
                    };
                    Products.Add(prod);
                }
                Pages.Add(i, Products);
            }

            return Ok(Pages);*/
        }


        // Get All Product in a Category
        [HttpGet("GetAllProductInCategory")]
        public ActionResult AllProductInCategory(int CatId)
        {
            var MainProduct = _Context.Products.Where(prod => prod.CatId == CatId);
            List<GetProduct> AllProducts = new List<GetProduct>();

            foreach (var item in MainProduct)
            {
                var Customer = _Context.Customers.Where(cus => cus.Id == item.CustId).FirstOrDefault();
                var Picture = _Context.Pictures.Where(pic => pic.ProdId == item.ProductId).Select(pic => pic.Photo).ToList();
                GetProduct prod = new GetProduct()
                {
                    Title = item.Title,
                    CustName = Customer.CustName,
                    CustPhoto = Customer.Photo,
                    Pictures = Picture,
                    Price = item.Price
                };
                AllProducts.Add(prod);
            }
            return Ok(AllProducts);
        }


        // Get All Customer's Product 
        [HttpGet("GetAllCustomer'sProducts")]
        public ActionResult AllCustomerProducts(int CustId)
        {
            var MainProduct = _Context.Products.Where(prod => prod.CustId == CustId);
            List<GetProduct> AllProducts = new List<GetProduct>();

            foreach (var item in MainProduct)
            {
                var Customer = _Context.Customers.Where(cus => cus.Id == item.CustId).FirstOrDefault();
                var Picture = _Context.Pictures.Where(pic => pic.ProdId == item.ProductId).Select(pic => pic.Photo).ToList();
                GetProduct prod = new GetProduct()
                {
                    Title = item.Title,
                    CustName = Customer.CustName,
                    CustPhoto = Customer.Photo,
                    Pictures = Picture,
                    Price = item.Price
                };
                AllProducts.Add(prod);
            }
            return Ok(AllProducts);
        }


        // Get All Customer's Product 
        [HttpGet("GetProduct")]
        public ActionResult GetProduct(int ProdId)
        {
            var MainProduct = _Context.Products.Where(prod => prod.ProductId == ProdId).FirstOrDefault();
            var Customer = _Context.Customers.Where(cus => cus.Id == MainProduct.CustId).FirstOrDefault();
            var Picture = _Context.Pictures.Where(pic => pic.ProdId == MainProduct.ProductId).Select(pic => pic.Photo).ToList();

            GetOneProduct prod = new GetOneProduct()
            {
                Title = MainProduct.Title,
                CustName = Customer.CustName,
                CustPhoto = Customer.Photo,
                Pictures = Picture,
                Price = MainProduct.Price,
                Description = MainProduct.Description
            };
            return Ok(prod);
        }


        [HttpDelete("DeleteProduct")]
        public ActionResult Remove(int Id)
        {
            var Product = _Context.Products.Where(prod => prod.ProductId == Id).FirstOrDefault();

            if (Product == null)
                return BadRequest("No");

            var ProdBill = _Context.Bills.Where(bill => bill.ProdId == Product.ProductId).FirstOrDefault();
            _Context.Bills.Remove(ProdBill);

            var ProdPic = _Context.Pictures.Where(pic => pic.ProdId == Product.ProductId);
            foreach (var pic in ProdPic)
            {
                _Context.Pictures.Remove(pic);
            }

            _Context.Products.Remove(Product);
            return Ok("Done");
        }


        [HttpGet("SearchForProduct")]
        public ActionResult Search(string Word)
        {
            var SearchProduct = _Context.Products.Where(prod => prod.Title.Contains(Word)).ToList();
            List<GetProduct> SearchList = new List<GetProduct>();

            foreach (var item in SearchProduct)
            {
                var Customer = _Context.Customers.Where(cus => cus.Id == item.CustId).FirstOrDefault();
                var Picture = _Context.Pictures.Where(pic => pic.ProdId == item.ProductId).Select(pic => pic.Photo).ToList();
                GetProduct prod = new GetProduct()
                {
                    Title = item.Title,
                    CustName = Customer.CustName,
                    CustPhoto = Customer.Photo,
                    Pictures = Picture,
                    Price = item.Price
                };
                SearchList.Add(prod);
            }
            return Ok(SearchList);
        }

        //[HttpGet("SortAscByPrice")]
        //[HttpGet("SortDscByPrice")]

    }
}




//[HttpGet("Get12item")]
//public ActionResult Get12item ()
//{
//    var MainProduct = _Context.Products.ToList();

//    List<GetProduct> AllProducts = new List<GetProduct>();

//    foreach (var item in MainProduct)
//    {
//        var Customer = _Context.Customers.Where(cus => cus.Id == item.CustId).FirstOrDefault();
//        var Picture = _Context.Pictures.Where(pic => pic.ProdId == item.ProductId).Select(pic => pic.Photo).ToList();
//        GetProduct prod = new GetProduct()
//        {
//            Title = item.Title,
//            CustName = Customer.CustName,
//            CustPhoto = Customer.Photo,
//            Pictures = Picture,
//            Price = item.Price
//        };
//        AllProducts.Add(prod);

//        for(int i =0; i < 12; i++)
//        {

//        }

//    }
//}


//[HttpPost("AddFavorite")]
//public ActionResult Favorite( int ProdID , int CustId)
//{
//    var findProd = _Context.Products.Where(prod => prod.ProductId == ProdID);
//    var findCust = _Context.Customers.Where(cust => cust.Id == CustId);


//}