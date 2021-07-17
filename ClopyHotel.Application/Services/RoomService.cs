using ClopyHotel.Application.Interfaces;
using ClopyHotel.Application.ViewModel;
using ClopyHotel.Domain.Commands;
using ClopyHotel.Domain.Core;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;
using System.Collections.Generic;

namespace ClopyHotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMediatorHandler _bus;

        public RoomService(IMediatorHandler bus, IRoomRepository roomRepository)
        {
            _bus = bus;
            _roomRepository = roomRepository;
        }

        public void Create(RoomViewModel room)
        {
            var createRoomCommand = new CreateRoomCommand(
                room.RoomName, 
                room.RoomTypeId, 
                room.Description);
            var response = _bus.SendCommand(createRoomCommand);
        }

        public IEnumerable<Room> GetRooms()
        {
            return _roomRepository.GetRooms();
        }
    }
}
