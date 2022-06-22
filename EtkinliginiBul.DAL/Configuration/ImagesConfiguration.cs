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
    public class ImagesConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Image);

            builder.HasOne(p => p.EventFK).WithMany(p => p.Images).HasForeignKey(p => p.EventID);
        }
    }
}
