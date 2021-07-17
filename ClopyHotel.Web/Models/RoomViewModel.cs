using System.Collections.Generic;
using ClopyHotel.Domain.Models;

namespace ClopyHotel.Web.Models
{
    public class ListRoomViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
    }
}
