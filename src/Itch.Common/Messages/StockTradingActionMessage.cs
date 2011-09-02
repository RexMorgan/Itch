using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class StockTradingActionMessage : TimestampedMessage
    {
        public StockTradingActionMessage()
        {
            
        }
        public StockTradingActionMessage(byte[] messageData)
            : base(messageData)
        {
            Stock = messageData.GetString(5, 8).Trim();
            TradingState = messageData.GetEnum<TradingState>(13);
            Reserved = messageData.GetString(14, 1);
            Reason = messageData.GetString(15, 4);
        }

        public string Stock { get; private set; }
        public TradingState TradingState { get; private set; }
        public string Reserved { get; private set; }
        public string Reason { get; private set; }
    }
}