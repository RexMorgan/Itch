using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class RegSHORestrictionMessage : TimestampedMessage
    {
        public RegSHORestrictionMessage()
        {
            
        }
        public RegSHORestrictionMessage(byte[] messageData)
            : base(messageData)
        {
            Stock = messageData.GetString(5, 8).Trim();
            RegSHOAction = messageData.GetEnum<RegSHOAction>(13);
        }

        public string Stock { get; private set; }
        public RegSHOAction RegSHOAction { get; private set; }
    }
}