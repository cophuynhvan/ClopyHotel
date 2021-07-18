using ClopyHotel.Application.Interfaces;
using ClopyHotel.Application.ViewModel;
using ClopyHotel.Domain.Commands;
using ClopyHotel.Domain.Core;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClopyHotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMediator _mediator;

        public RoomService(IMediatorHandler bus, IMediator mediator, IRoomRepository roomRepository)
        {
            _bus = bus;
            _mediator = mediator;
            _roomRepository = roomRepository;
        }

        public async Task<Room> Create(RoomViewModel room)
        {
            var createRoomCommand = new CreateRoomCommand(
                room.RoomName,
                room.RoomTypeId,
                room.Description);
            // var response = _bus.SendCommand(createRoomCommand);
            var response = await _mediator.Send(createRoomCommand);

            return response;
        }

        public IEnumerable<Room> GetRooms()
        {
            return _roomRepository.GetRooms();
        }
    }
}
