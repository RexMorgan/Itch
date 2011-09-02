using System;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class OrderReplacedMessage : TimestampedMessage
    {
        public OrderReplacedMessage()
        {
            
        }
        public OrderReplacedMessage(byte[] messageData)
            : base(messageData)
        {
            OriginalOrderReferenceNumber = messageData.GetUInt64(5);
            NewOrderReferenceNumber = messageData.GetUInt64(13);
            Shares = messageData.GetUInt32(21);
            Price = messageData.GetUInt32(25);
        }

        public UInt64 OriginalOrderReferenceNumber { get; private set; }
        public UInt64 NewOrderReferenceNumber { get; private set; }
        public uint Shares { get; private set; }
        public uint Price { get; private set; }
    }
}