using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XO_CodeFirst.Model
{
    public partial class Administrator
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string AdminPass { get; set; }
        public string Email { get; set; }
    }

    public class LoginAdmin
    {
        public string Email { get; set; }
        public string AdminPass { get; set; }
    }
}
