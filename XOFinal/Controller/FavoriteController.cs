using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;
using XOFinal.Models;

namespace XOFinal.Controller
{
    [ApiController]
    [Route("Favorite")]
    public class FavoriteController : ControllerBase
    {
        XOContext _Context;
        public FavoriteController(XOContext context)
        {
            _Context = context;
        }

        [HttpPost("AddFavorite")]
        public ActionResult AddFavorite(int CustId, int ProdId)
        {
            var CheckFavorite = _Context.Favorites.Where(Fav => Fav.CustId == CustId && Fav.ProdId == ProdId);
            if (CheckFavorite == null)
            {
                var CheckCust = _Context.Customers.Where(cus => cus.Id == CustId).FirstOrDefault();
                var CheckProd = _Context.Products.Where(prod => prod.ProductId == ProdId).FirstOrDefault();
                if (CheckCust != null && CheckProd != null)
                {
                    Favorite AddFav = new Favorite()
                    {
                        CustId = CustId,
                        ProdId = ProdId
                    };
                    _Context.Favorites.Add(AddFav);
                    _Context.SaveChanges();
                    return Ok("Done");
                }
                else
                    return BadRequest("No");
            }
            else
                return BadRequest("No");
        }


        [HttpDelete("RemoveFavorite")]
        public ActionResult RemoveFavorite(int CustId, int ProdId)
        {
            var CheckFavorite = _Context.Favorites.Where(Fav => Fav.CustId == CustId && Fav.ProdId == ProdId).FirstOrDefault();
            if (CheckFavorite != null)
            {
                var CheckCust = _Context.Customers.Where(cus => cus.Id == CustId).FirstOrDefault();
                var CheckProd = _Context.Products.Where(prod => prod.ProductId == ProdId).FirstOrDefault();
                if (CheckCust != null && CheckProd != null)
                {
                    _Context.Favorites.Remove(CheckFavorite);
                    _Context.SaveChanges();
                    return Ok("Done");
                }
                else
                    return BadRequest("No");
            }
            else
                return BadRequest("No");
        }
    }
}
