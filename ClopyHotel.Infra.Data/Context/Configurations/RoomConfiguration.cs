using ClopyHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClopyHotel.Infra.Data
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> entity)
        {
            entity.HasKey(e => e.RoomId);

            entity.ToTable("Room", "Hotel");
            entity.Property(e => e.RoomName)
                .IsUnicode(true)
                .HasMaxLength(1000);
            entity.HasOne(e => e.RoomType)
                .WithMany(e => e.Room)
                .HasForeignKey(e => e.RoomTypeId);
        }
    }
}
