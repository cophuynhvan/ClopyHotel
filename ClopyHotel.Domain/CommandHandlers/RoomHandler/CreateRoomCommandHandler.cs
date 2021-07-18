using ClopyHotel.Domain.Commands;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ClopyHotel.Domain.CommandHandlers
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
    {
        private readonly IRoomRepository _roomRepository;
        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room()
            {
                RoomName = request.RoomName,
                RoomTypeId = request.RoomTypeId,
                Description = request.Description
            };
            await _roomRepository.Add(room);
            return room;
        }
    }
}
