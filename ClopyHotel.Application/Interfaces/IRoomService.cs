using ClopyHotel.Domain.Models;
using ClopyHotel.Application.ViewModel;
using System.Collections.Generic;

namespace ClopyHotel.Application.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetRooms();
        void Create(RoomViewModel room);
    }
}
