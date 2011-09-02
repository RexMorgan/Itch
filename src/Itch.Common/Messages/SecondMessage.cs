using Itch.Common.Messages.BaseMessages;

namespace Itch.Common.Messages
{
    public class SecondMessage : Message
    {
        public SecondMessage()
        {
            
        }
        public SecondMessage(byte[] messageData)
            : base(messageData)
        {
            SecondsSinceMidnight = messageData.GetUInt32(1);
        }

        public uint SecondsSinceMidnight { get; set; }
    }
}