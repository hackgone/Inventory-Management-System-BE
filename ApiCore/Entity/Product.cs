using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ProductSku { get; set; }
        public Boolean Published { get; set; }
        public Boolean Deleted { get; set; }
        public Byte[] RowVersion { get; set; }
        public String Provider { get;set; }
    }
}
        