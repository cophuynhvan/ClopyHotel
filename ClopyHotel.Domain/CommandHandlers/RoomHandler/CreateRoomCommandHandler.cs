using MediatR;
using ClopyHotel.Domain.Commands;
using System.Threading.Tasks;
using System.Threading;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;

namespace ClopyHotel.Domain.CommandHandlers
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
    {
        private readonly IRoomRepository _roomRepository;
        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room()
            {
                RoomName = request.RoomName,
                RoomTypeId = request.RoomTypeId,
                Description = request.Description
            };
            var obj = _roomRepository.Add(room);
            return obj;
        }
    }
}
