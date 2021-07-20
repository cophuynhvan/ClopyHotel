using ClopyHotel.Domain.Models;
using MediatR;
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
