using System.Collections.Generic;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;
using URF.Core.Abstractions;
using System.Threading.Tasks;
using System.Linq;

namespace ClopyHotel.Infra.Data
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<RoomType> _roomTypeRepository;

        public RoomTypeRepository(IUnitOfWork uow, IRepository<RoomType> roomTypeRepository)
        {
            _uow = uow;
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<RoomType> Add(RoomType roomType)
        {
            _roomTypeRepository.Insert(roomType);
            var result = await _uow.SaveChangesAsync();
            return result > 0 ? roomType : null;
        }

        public async Task<RoomType> GetRoomType(int roomTypeId)
        {
            var roomType = await _roomTypeRepository.FindAsync(roomTypeId);
            return roomType;
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            var roomTypes = _roomTypeRepository.Queryable()
                .Where(r => r.Active)
                .AsEnumerable();
            return roomTypes;
        }
    }
}
