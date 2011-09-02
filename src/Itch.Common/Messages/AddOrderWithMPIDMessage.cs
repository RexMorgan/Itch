namespace Itch.Common.Messages
{
    public class AddOrderWithMPIDMessage : AddOrderMessage
    {
        public AddOrderWithMPIDMessage()
        {
            
        }
        public AddOrderWithMPIDMessage(byte[] messageData)
            : base(messageData)
        {
            Attribution = messageData.GetString(30, 4);
        }

        public string Attribution { get; private set; }
    }
}