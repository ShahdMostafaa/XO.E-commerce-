using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XO_CodeFirst.Controller
{
    [ApiController]
    [Route("Bill")]
    public class BillController : ControllerBase
    {
        XOContext _Context;
        public BillController(XOContext context)
        {
            _Context = context;
        }
        //[HttpPost("AddPrpductInformation")]
        //[HttpPost("AddProductPictures")]
        //[HttpPost("AddBill")]
    }
}
