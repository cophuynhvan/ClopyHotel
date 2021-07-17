using ClopyHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClopyHotel.Infra.Data
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> entity)
        {
            entity.HasKey(e => e.RoomTypeId);
            entity.ToTable("RoomType", "Hotel");
            entity.Property(e => e.RoomTypeName)
                .IsUnicode(true)
                .HasMaxLength(100);
            entity.HasMany(e => e.Room)
                .WithOne(r => r.RoomType)
                .HasForeignKey(e => e.RoomTypeId);
        }

    }
}
