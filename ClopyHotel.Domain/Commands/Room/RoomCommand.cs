using ClopyHotel.Domain.Core;

namespace ClopyHotel.Domain.Commands
{
    public abstract class RoomCommand : Command
    {
        public int RoomId { get; protected set; }
        public string RoomName { get; protected set; }
        public int RoomTypeId { get; protected set; }
        public string Description { get; protected set; }

    }
}
