using ClopyHotel.Domain.Models;
using System.Collections.Generic;

namespace ClopyHotel.Application.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int RoomTypeId { get; set; }
        public string Description { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
