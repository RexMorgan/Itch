using Itch.Common.Enums;

namespace Itch.Common.Messages.BaseMessages
{
    public abstract class Message
    {
        protected Message()
        {
            
        }
        protected Message(byte[] messageData)
        {
            MessageType = messageData.GetEnum<MessageType>(0);
        }

        public MessageType MessageType { get; private set; }
    }
}