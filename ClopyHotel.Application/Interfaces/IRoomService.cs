using ClopyHotel.Application.ViewModel;
using ClopyHotel.Domain.Models;
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
