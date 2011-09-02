using System;
using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class CrossTradeMessage : TimestampedMessage
    {
        public CrossTradeMessage()
        {
            
        }
        public CrossTradeMessage(byte[] messageData)
            : base(messageData)
        {
            Shares = messageData.GetUInt64(5);
            Stock = messageData.GetString(13, 8).Trim();
            CrossPrice = messageData.GetUInt32(21);
            MatchNumber = messageData.GetUInt64(25);
            CrossType = messageData.GetEnum<CrossType>(33);
        }

        public UInt64 Shares { get; private set; }
        public string Stock { get; private set; }
        public uint CrossPrice { get; private set; }
        public UInt64 MatchNumber { get; private set; }
        public CrossType CrossType { get; private set; }
    }
}