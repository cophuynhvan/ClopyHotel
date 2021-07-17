using System.Collections.Generic;
using ClopyHotel.Domain.Models;

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
