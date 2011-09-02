using System;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class OrderDeletedMessage : TimestampedMessage
    {
        public OrderDeletedMessage()
        {
            
        }
        public OrderDeletedMessage(byte[] messageData)
            : base(messageData)
        {
            OrderReferenceNumber = messageData.GetUInt64(5);
        }

        public UInt64 OrderReferenceNumber { get; private set; }
    }
}