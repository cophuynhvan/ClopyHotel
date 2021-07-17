using System.Collections.Generic;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;
using URF.Core.Abstractions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClopyHotel.Infra.Data
{
    public class RoomRepository : IRoomRepository 
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Room> _roomRepository;
        
        public RoomRepository(IUnitOfWork uow, IRepository<Room> roomRepository)
        {
            _uow = uow;
            _roomRepository = roomRepository;
        }
        public async Task<Room> GetRoom(int roomId)
        {
            var room = await _roomRepository.FindAsync(roomId);
            return room;
        }
        public IEnumerable<Room> GetRooms()
        {
            var rooms = _roomRepository.Queryable()
                                .Where(x => x.RoomId > 0)
                                .Include(x => x.RoomType)
                                .AsEnumerable();
            return rooms;
        }
        public async Task<Room> Add(Room room)
        {
            _roomRepository.Insert(room);
            var result = await _uow.SaveChangesAsync();
            return result > 0 ? room : null;
        }
    }
}
