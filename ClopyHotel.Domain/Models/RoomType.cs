namespace ClopyHotel.Domain.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public bool Active { get; set; } = true;
    }
}
