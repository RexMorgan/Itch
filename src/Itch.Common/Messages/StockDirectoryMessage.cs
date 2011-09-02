using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class StockDirectoryMessage : TimestampedMessage
    {
        public StockDirectoryMessage()
        {
            
        }
        public StockDirectoryMessage(byte[] messageData)
            : base(messageData)
        {
            Stock = messageData.GetString(5, 8).Trim();
            MarketCategory = messageData.GetEnum<MarketCategory>(13);
            FinancialStatusIndicator = messageData.GetEnum<FinancialStatusIndicator>(14);
            RoundLotSize = messageData.GetUInt32(15);
            RoundLotsOnly = messageData.GetEnum<RoundLotsOnly>(19);
        }

        public string Stock { get; private set; }
        public MarketCategory MarketCategory { get; private set; }
        public FinancialStatusIndicator FinancialStatusIndicator { get; private set; }
        public uint RoundLotSize { get; private set; }
        public RoundLotsOnly RoundLotsOnly { get; private set; }
    }
}