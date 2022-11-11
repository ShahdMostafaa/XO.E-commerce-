using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XO_CodeFirst.Model;

namespace XO_CodeFirst.Controller
{
    [ApiController]
    [Route("Picture")]
    public class PictureController : ControllerBase
    {
        XOContext _Context;
        public PictureController(XOContext context)
        {
            _Context = context;
        }
        // Add picture for customer
        [HttpPost("AddCustomer'sPicture")]
        public ActionResult CustPicture(IFormFile photo)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images";

            string name = DateTime.Now.Ticks.ToString() + photo.FileName;

            string filePath = fullPath + "/" + name;

            var stream = new FileStream(filePath, FileMode.Create);

            return Ok("Images/" + name);
        }

        // Add prouduct pictures
        //product id
        [HttpPost("AddProduct'sPictures")]
        public ActionResult ProdPictures(List<IFormFile> photos)
        {
            List<string> Pictures = new List<string>();
            foreach (var item in photos)
            {
                string fullPath = Directory.GetCurrentDirectory() + "/Images";

                string name = DateTime.Now.Ticks.ToString() + item.FileName;

                string filePath = fullPath + "/" + name;

                var stream = new FileStream(filePath, FileMode.Create);

                Pictures.Add(name);
            }
            return Ok(Pictures);

        }
    }
}
