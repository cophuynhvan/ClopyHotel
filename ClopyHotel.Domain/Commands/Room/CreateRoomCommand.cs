using MediatR;
using ClopyHotel.Domain.Models;
namespace ClopyHotel.Domain.Commands
{
    public class CreateRoomCommand : IRequest<Room>
    {
        public CreateRoomCommand(string name, int roomTypeId, string description)
        {
            RoomName = name;
            RoomTypeId = roomTypeId;
            Description = description;
        }

        public string RoomName { get; private set; }
        public int RoomTypeId { get; private set; }
        public string Description { get; private set; }
    }
}
