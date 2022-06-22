using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Configuration
{
    public class OpenAddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AddressName).IsRequired();
            builder.Property(p => p.Lat).IsRequired();
            builder.Property(p => p.Lng).IsRequired();
        }
    }
}
