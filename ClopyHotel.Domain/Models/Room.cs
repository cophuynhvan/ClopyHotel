namespace ClopyHotel.Domain.Models
{
    public class Room
    {
        public Room()
        {

        }
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public int RoomTypeId { get; set; }
        public string Description { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
