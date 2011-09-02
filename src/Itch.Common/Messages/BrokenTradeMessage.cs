using System;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class BrokenTradeMessage : TimestampedMessage
    {
        public BrokenTradeMessage()
        {
            
        }
        public BrokenTradeMessage(byte[] messageData)
            : base(messageData)
        {
            MatchNumber = messageData.GetUInt64(5);
        }

        public UInt64 MatchNumber { get; private set; }
    }
}