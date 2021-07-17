using System;

namespace ClopyHotel.Domain.Core
{ 
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }
        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
