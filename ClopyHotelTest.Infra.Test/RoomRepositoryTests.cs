using ClopyHotel.Domain.Models;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Infra.Data;
using ClopyHotelTest.Infra.Test.DataFactory;
using Xunit;
using System.Linq;
using Moq;
using URF.Core.Abstractions;
using URF.Core.EF;

namespace ClopyHotelTest.Infra.Test
{
    public class RoomRepositoryTests
    {
        private readonly ClopyHotelInMemoryEntities _context;
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Room> _iRoomRepository;
        
        public RoomRepositoryTests()
        {
            _context = InMemoryFactory.CreateInMemoryDbContext();
            _uow = new UnitOfWork(_context);
            _iRoomRepository = new Repository<Room>(_context);
        }

        [Fact]
        public async void Room_InsertNewRoom_ReturnSuccess()
        {
            // Set up
            var room = new Room() { RoomName = "01", RoomTypeId = 1, Description = "" };

            // Action
            IRoomRepository roomRepository = new RoomRepository(_uow, _iRoomRepository);
            var result = await roomRepository.Add(room);

            // Assert 
            Assert.True(result.RoomId > 0);
            Assert.Equal("01", result.RoomName);
            Assert.Equal(1, _context.Rooms.Count());
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        public void Room_FindExistingRoom(int roomId, bool found)
        {
            IRoomRepository roomRepository = new RoomRepository(_uow, _iRoomRepository);
            var room = roomRepository.GetRoom(roomId);

            Assert.Equal(found, room != null);
        }
    }
}
