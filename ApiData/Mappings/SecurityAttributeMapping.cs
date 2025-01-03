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
    class SecurityAttributeMapping:IEntityTypeConfiguration<SecurityAttribute>
    {
        public void Configure(EntityTypeBuilder<SecurityAttribute> builder)
        {
            builder.ToTable("SecurityAttribute"); // Specify the table name
        }
    }
}
