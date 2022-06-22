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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.SeatNo).IsRequired();
            builder.Property(p => p.SeatPrice).IsRequired();

            builder.HasOne(p => p.SalonFK).WithMany(p => p.Seats).HasForeignKey(p => p.SalonID);
        }
    }
}
