using Itch.Common.Enums;
using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class SystemEventMessage : TimestampedMessage
    {
        public SystemEventMessage()
        {
            
        }
        public SystemEventMessage(byte[] messageData)
            : base(messageData)
        {
            SystemEvent = messageData.GetEnum<SystemEventCode>(5);
        }

        public SystemEventCode SystemEvent { get; private set; }
    }
}