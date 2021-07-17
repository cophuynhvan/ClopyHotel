using ClopyHotel.Domain.Core;

namespace ClopyHotel.Domain.Commands
{
    public abstract class RoomTypeCommand : Command
    {
        public int RoomTypeId { get; protected set; }
        public string RoomTypeName { get; protected set; }
        public bool Active { get; protected set; }
    }
}
