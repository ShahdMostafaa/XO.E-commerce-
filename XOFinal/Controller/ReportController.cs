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
    [Route("Report")]
    public class ReportController : ControllerBase
    {
        XOContext _Context;
        public ReportController(XOContext context)
        {
            _Context = context;
        }

        [HttpPost("AddReport")]
        public ActionResult AddReport(int CustId, int ProdId)
        {
            var CheckReport = _Context.Favorites.Where(Rep => Rep.CustId == CustId && Rep.ProdId == ProdId).FirstOrDefault();
            if (CheckReport == null)
            {
                var CheckCust = _Context.Customers.Where(cus => cus.Id == CustId).FirstOrDefault();
                var CheckProd = _Context.Products.Where(prod => prod.ProductId == ProdId).FirstOrDefault();
                if (CheckCust != null && CheckProd != null)
                {
                    Report Rep = new Report()
                    {
                        CustId = CustId,
                        ProdId = ProdId
                    };
                    _Context.Reports.Add(Rep);
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
