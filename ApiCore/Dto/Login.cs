using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dto
{
    public class Login
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

    }
}
