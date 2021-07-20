﻿using MediatR;

namespace ClopyHotel.Domain.Core
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
