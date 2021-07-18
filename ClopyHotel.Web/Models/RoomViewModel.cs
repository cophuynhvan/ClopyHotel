using ClopyHotel.Domain.Models;
using System.Collections.Generic;

namespace ClopyHotel.Web.Models
{
    public class ListRoomViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
    }
}
