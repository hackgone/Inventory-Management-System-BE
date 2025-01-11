using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiData.Mappings
{
    public class ProductInventoryMapping : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.ToTable("ProductInventory")
                .HasOne(pi => pi.product)
                .WithMany()
                .HasForeignKey(pi => pi.ProductId);

            builder.Property(pi => pi.RowVersion)
           .IsRowVersion()
           .HasColumnName("Rowversion");

            //// Disabling concurrency tracking for the RowVersion column
            //builder.Property(pi => pi.RowVersion)
            //    .IsRowVersion()
            //    .IsConcurrencyToken(false); // Disables concurrency tracking for RowVersion column
        }
    }
}
