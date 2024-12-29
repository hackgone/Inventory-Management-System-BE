using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Entity
{
    public class UserRoleMapping
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
