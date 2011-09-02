namespace Itch.Common.Messages.BaseMessages
{
    public abstract class TimestampedMessage : Message
    {
        protected TimestampedMessage()
        {
            
        }
        protected TimestampedMessage(byte[] messageData)
            : base(messageData)
        {
            NanosecondsSinceLastTimestamp = messageData.GetUInt32(1);
        }

        public uint NanosecondsSinceLastTimestamp { get; private set; }
    }
}