using System.Collections.Generic;

namespace ClopyHotel.Domain.Models
{
    public class RoomType
    {
        public RoomType()
        {
            Room = new HashSet<Room>();
        }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<Room> Room { get; set; }
    }
}
