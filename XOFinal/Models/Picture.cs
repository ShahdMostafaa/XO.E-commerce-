using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XO_CodeFirst.Model
{
    public partial class Picture
    {

        public int PictureId { get; set; }
        public int? ProdId { get; set; }
        public string Photo { get; set; }

        public virtual Product Prod { get; set; }
    }
}
