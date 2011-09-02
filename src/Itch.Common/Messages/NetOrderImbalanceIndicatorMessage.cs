using System;
using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class NetOrderImbalanceIndicatorMessage : TimestampedMessage
    {
        public NetOrderImbalanceIndicatorMessage()
        {
            
        }
        public NetOrderImbalanceIndicatorMessage(byte[] messageData)
            : base(messageData)
        {
            PairedShares = messageData.GetUInt64(5);
            ImbalanceShares = messageData.GetUInt64(13);
            ImbalanceDirection = messageData.GetEnum<ImbalanceDirection>(21);
            Stock = messageData.GetString(22, 8).Trim();
            FarPrice = messageData.GetUInt32(30);
            NearPrice = messageData.GetUInt32(34);
            CurrentReferencePrice = messageData.GetUInt32(38);
            CrossType = messageData.GetEnum<CrossType>(42);
            PriceVariationIndicator = messageData.GetEnum<PriceVariationIndicator>(43);
        }

        public UInt64 PairedShares { get; private set; }
        public UInt64 ImbalanceShares { get; private set; }
        public ImbalanceDirection ImbalanceDirection { get; private set; }
        public string Stock { get; private set; }
        public uint FarPrice { get; private set; }
        public uint NearPrice { get; private set; }
        public uint CurrentReferencePrice { get; private set; }
        public CrossType CrossType { get; private set; }
        public PriceVariationIndicator PriceVariationIndicator { get; private set; }
    }
}