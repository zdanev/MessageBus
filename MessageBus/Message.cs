using System;

namespace MessageBus
{
    public abstract class Message
    {
        public Guid Id { get; set; }
    }
}