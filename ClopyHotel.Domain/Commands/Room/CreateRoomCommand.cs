using MediatR;
using ClopyHotel.Domain.Models;
namespace ClopyHotel.Domain.Commands
{
    public class CreateRoomCommand : RoomCommand, IRequest<Room>
    {
        public CreateRoomCommand(string name, int roomTypeId, string description)
        {
            RoomName = name;
            RoomTypeId = roomTypeId;
            Description = description;
        }
    }
}
