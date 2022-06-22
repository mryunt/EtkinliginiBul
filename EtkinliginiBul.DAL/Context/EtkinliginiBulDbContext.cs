using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Context
{
    public class EtkinliginiBulDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B5VF1VT;Database=Etkinligini-Bul;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Images> Imagesses { get; set; }
    }
}
