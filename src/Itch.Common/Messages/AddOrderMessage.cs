using System;
using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class AddOrderMessage : TimestampedMessage
    {
        public AddOrderMessage()
        {
            
        }
        public AddOrderMessage(byte[] messageData)
            : base(messageData)
        {
            OrderReferenceNumber = messageData.GetUInt64(5);
            BuySellIndicator = messageData.GetEnum<BuySellIndicator>(13);
            Shares = messageData.GetUInt32(14);
            Stock = messageData.GetString(18, 8).Trim();
            Price = messageData.GetUInt32(26);
        }

        public UInt64 OrderReferenceNumber { get; private set; }
        public BuySellIndicator BuySellIndicator { get; private set; }
        public uint Shares { get; private set; }
        public string Stock { get; private set; }
        public uint Price { get; private set; }
    }
}