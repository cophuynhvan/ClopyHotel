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
        private readonly IRepository<Room> _iRepository;
        private readonly IRoomRepository _iRoomRepository;
        
        public RoomRepositoryTests()
        {
            // Set up inmemory context and initate sample data
            _context = InMemoryFactory.CreateInMemoryDbContext();
            InitiateData.InitiateDataContext(_context);
            
            // unit of work and repository
            _uow = new UnitOfWork(_context);
            _iRepository = new Repository<Room>(_context);

            // room repository
            _iRoomRepository = new RoomRepository(_uow, _iRepository);
        }

        [Fact]
        public async void Room_InsertNewRoom_ReturnSuccess()
        {
            // Set up
            var room = new Room() { RoomName = "01", RoomTypeId = 1, Description = "" };

            // Action
            var result = await _iRoomRepository.Add(room);

            // Assert 
            Assert.True(result.RoomId > 0);
            Assert.Equal("01", result.RoomName);
            Assert.Equal(11, _context.Rooms.Count());
        }

        [Fact]
        public void Room_FindExistingRooms()
        {
            // Action
            var rooms = _iRoomRepository.GetRooms();

            // Assert
            Assert.True(rooms.Count() > 0);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async void Room_FindRoomIdLessThanOrEqualZero_ReturnNull(int roomId)
        {
            // Action
            var room = await _iRoomRepository.GetRoom(roomId);

            // Assert
            Assert.Null(room);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async void Room_FindRoomByIdFromOneToTen_ReturnNotNull(int roomId)
        {
            // Action
            var room = await _iRoomRepository.GetRoom(roomId);

            // Assert
            Assert.NotNull(room);
        }
    }
}
