using ClopyHotel.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClopyHotel.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetRoom(int RoomId);
        IEnumerable<Room> GetRooms();
        Task<Room> Add(Room room);
    }
}
