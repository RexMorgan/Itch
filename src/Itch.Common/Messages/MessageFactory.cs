using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public static class MessageFactory
    {
        public static Message CreateMessage(byte[] messageData)
        {
            var messageType = messageData.GetEnum<MessageType>(0);
            switch(messageType)
            {
                case MessageType.Timestamp:
                    return new SecondMessage(messageData);
                case MessageType.SystemEvent:
                    return new SystemEventMessage(messageData);
                case MessageType.StockDirectory:
                    return new StockDirectoryMessage(messageData);
                case MessageType.StockTradingAction:
                    return new StockTradingActionMessage(messageData);
                case MessageType.RegSHORestriction:
                    return new RegSHORestrictionMessage(messageData);
                case MessageType.MarketParticipantPosition:
                    return new MarketParticipantPositionMessage(messageData);
                case MessageType.AddOrder:
                    return new AddOrderMessage(messageData);
                case MessageType.AddOrderWithMPID:
                    return new AddOrderWithMPIDMessage(messageData);
                case MessageType.OrderExecuted:
                    return new OrderExecutedMessage(messageData);
                case MessageType.OrderExecutedWithPrice:
                    return new OrderExecutedWithPriceMessage(messageData);
                case MessageType.OrderCancelled:
                    return new OrderCancelMessage(messageData);
                case MessageType.OrderDeleted:
                    return new OrderDeletedMessage(messageData);
                case MessageType.OrderReplaced:
                    return new OrderReplacedMessage(messageData);
                case MessageType.TradeMessageNonCross:
                    return new TradeNonCrossMessage(messageData);
                case MessageType.CrossTradeMessage:
                    return new CrossTradeMessage(messageData);
                case MessageType.BrokenTrade:
                    return new BrokenTradeMessage(messageData);
                case MessageType.NetOrderImbalanceIndicator:
                    return new NetOrderImbalanceIndicatorMessage(messageData);
                default:
                    return null;
            }
        }
    }
}