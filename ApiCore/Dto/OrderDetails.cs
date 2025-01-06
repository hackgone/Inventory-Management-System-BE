using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dto
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ProductId { get; set; }


    }
}
