using System;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class OrderExecutedMessage : TimestampedMessage
    {
        public OrderExecutedMessage()
        {
            
        }
        public OrderExecutedMessage(byte[] messageData)
            : base(messageData)
        {
            OrderReferenceNumber = messageData.GetUInt64(5);
            ExecutedShares = messageData.GetUInt32(13);
            MatchNumber = messageData.GetUInt64(17);
        }

        public UInt64 OrderReferenceNumber { get; private set; }
        public uint ExecutedShares { get; private set; }
        public UInt64 MatchNumber { get; private set; }
    }
}