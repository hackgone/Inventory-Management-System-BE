using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiCore.Entity
{
    public class ProductInventory
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        //[ForeignKey("Products")]
        public Product product { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
