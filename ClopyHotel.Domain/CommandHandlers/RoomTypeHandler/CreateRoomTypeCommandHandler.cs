using MediatR;
using ClopyHotel.Domain.Commands;
using System.Threading.Tasks;
using System.Threading;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;

namespace ClopyHotel.Domain.CommandHandlers
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomType>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        public CreateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public Task<RoomType> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = new RoomType()
            {
                RoomTypeName = request.RoomTypeName,
                Active = request.Active
            };

            return _roomTypeRepository.Add(roomType);
        }
    }
}
