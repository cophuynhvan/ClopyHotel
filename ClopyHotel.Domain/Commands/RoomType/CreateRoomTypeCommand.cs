using ClopyHotel.Domain.Models;
using MediatR;

namespace ClopyHotel.Domain.Commands
{
    public class CreateRoomTypeCommand : RoomTypeCommand, IRequest<RoomType>
    {
        public CreateRoomTypeCommand(string roomTypeName, bool active)
        {
            RoomTypeName = roomTypeName;
            Active = active;
        }
    }
}
