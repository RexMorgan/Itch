using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class MarketParticipantPositionMessage : TimestampedMessage
    {
        public MarketParticipantPositionMessage()
        {
            
        }
        public MarketParticipantPositionMessage(byte[] messageData)
            : base(messageData)
        {
            MPID = messageData.GetString(5, 4);
            Stock = messageData.GetString(9, 8);
            PrimaryMarketMaker = messageData.GetEnum<PrimaryMarketMaker>(17);
            MarketMakerMode = messageData.GetEnum<MarketMakerMode>(18);
            MarketParticipantState = messageData.GetEnum<MarketParticipantState>(19);
        }

        public string MPID { get; private set; }
        public string Stock { get; private set; }
        public PrimaryMarketMaker PrimaryMarketMaker { get; private set; }
        public MarketMakerMode MarketMakerMode { get; private set; }
        public MarketParticipantState MarketParticipantState { get; private set; }
    }
}