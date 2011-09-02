using System;
using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class TradeNonCrossMessage : TimestampedMessage
    {
        public TradeNonCrossMessage()
        {
            
        }
        public TradeNonCrossMessage(byte[] messageData)
            : base(messageData)
        {
            OrderReferenceNumber = messageData.GetUInt64(5);
            BuySellIndicator = messageData.GetEnum<BuySellIndicator>(13);
            Shares = messageData.GetUInt32(14);
            Stock = messageData.GetString(18, 8).Trim();
            Price = messageData.GetUInt32(26);
            MatchNumber = messageData.GetUInt64(30);
        }

        public UInt64 OrderReferenceNumber { get; private set; }
        public BuySellIndicator BuySellIndicator { get; private set; }
        public uint Shares { get; private set; }
        public string Stock { get; private set; }
        public uint Price { get; private set; }
        public UInt64 MatchNumber { get; private set; }
    }
}