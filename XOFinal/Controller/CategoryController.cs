using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XO_CodeFirst.Controller
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        XOContext _Context;
        public CategoryController(XOContext context)
        {
            _Context = context;
        }


        [HttpGet("GetAllCategory")]
        public ActionResult All()
        {
            var AllCategory = _Context.Categories.Select(cat => cat.Name);
            return Ok(AllCategory);
        }
    }
}
