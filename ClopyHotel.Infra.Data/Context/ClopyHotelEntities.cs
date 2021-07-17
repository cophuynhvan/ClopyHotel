using Microsoft.EntityFrameworkCore;
using ClopyHotel.Domain.Models;

namespace ClopyHotel.Infra.Data
{
    public class ClopyHotelEntities : DbContext 
    {
        public ClopyHotelEntities(DbContextOptions options) : base(options)
        { 
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // EF Core 3.* must use Proxies and SqlServer extension
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=localhost;Database=ClopyHotel;Trusted_Connection=True;MultipleActiveResultSets=true;App=ClopyHotel;");

                // EF Core 5.0 or above can use UseSqlServer
                // optionsBuilder.UseSqlServer("Server=localhost;Database=ClopyHotel;Trusted_Connection=True;MultipleActiveResultSets=true;App = ClopyHotel;");
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
