using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dto
{
    public class ProductOrder
    {
       
        public String Name { get; set; }
        public String Email { get; set; }
        public int ProductID { get; set; }
        public ProductOrder(String name, String email, int productID)
        {
            Name = name;
            Email = email;
            ProductID = productID;
        }
    }
}
