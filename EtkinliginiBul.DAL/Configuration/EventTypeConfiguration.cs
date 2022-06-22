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
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
        }
    }
}
