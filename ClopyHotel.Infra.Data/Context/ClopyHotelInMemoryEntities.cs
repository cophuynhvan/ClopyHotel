using ClopyHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClopyHotel.Infra.Data
{
    public class ClopyHotelInMemoryEntities : DbContext
    {
        public ClopyHotelInMemoryEntities(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // EF Core 3.* must use Proxies and SqlServer extension
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        }
    }
}
