using System;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class OrderCancelMessage : TimestampedMessage
    {
        public OrderCancelMessage()
        {
            
        }
        public OrderCancelMessage(byte[] messageData)
            : base(messageData)
        {
            OrderReferenceNumber = messageData.GetUInt64(5);
            CanceledShares = messageData.GetUInt32(13);
        }

        public UInt64 OrderReferenceNumber { get; private set; }
        public uint CanceledShares { get; private set; }
    }
}