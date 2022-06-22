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
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.AddresId).IsRequired();

            builder.HasOne(p => p.AddressFK).WithMany(p => p.Salons).HasForeignKey(p => p.AddresId);
        }
    }
}
