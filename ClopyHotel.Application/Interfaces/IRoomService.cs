using ClopyHotel.Domain.Models;
using ClopyHotel.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClopyHotel.Application.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetRooms();
        Task<Room> Create(RoomViewModel room);
    }
}
