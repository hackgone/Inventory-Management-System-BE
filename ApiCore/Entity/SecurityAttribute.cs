using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ApiCore.Entity
{
    public class SecurityAttribute
    {
        [Key]
        public int id {  get; set; }
        public int userid { get; set; }
        public string JwtToken { get; set; }
        public User User { get; set; }
        public SecurityAttribute() { }
        public SecurityAttribute(int userId, string jwtToken)
        {
            this.userid = userId;
            this.JwtToken = jwtToken;
        }

    }
}
