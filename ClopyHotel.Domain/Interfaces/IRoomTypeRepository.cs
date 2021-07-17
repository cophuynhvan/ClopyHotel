using ClopyHotel.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ClopyHotel.Domain.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> GetRoomType(int roomTypeId);
        IEnumerable<RoomType> GetRoomTypes();
        Task<RoomType> Add(RoomType roomType);
    }
}
