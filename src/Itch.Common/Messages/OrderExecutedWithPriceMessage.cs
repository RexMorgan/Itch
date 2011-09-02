using Itch.Common.Enums;

namespace Itch.Common.Messages
{
    public class OrderExecutedWithPriceMessage : OrderExecutedMessage
    {
        public OrderExecutedWithPriceMessage()
        {
            
        }
        public OrderExecutedWithPriceMessage(byte[] messageData)
            : base(messageData)
        {
            Printable = messageData.GetEnum<Printable>(25);
            ExecutionPrice = messageData.GetUInt32(26);
        }

        public Printable Printable { get; private set; }
        public uint ExecutionPrice { get; private set; }
    }
}