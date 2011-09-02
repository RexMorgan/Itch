using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Itch.Common;
using Itch.Common.Enums;
using Itch.Common.Messages;
using Itch.Common.Messages.BaseMessages;
using log4net;
using log4net.Config;
using MassTransit;

namespace Itch.Consumer
{
    public class Program
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        static void BootstrapLogger()
        {
            string configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                typeof(Program).Namespace + ".log4net.xml");

            XmlConfigurator.ConfigureAndWatch(new FileInfo(configFileName));

            _log.Info("Loading " + typeof(Program).Namespace + " Services...");
        }

        static void Main()
        {
            var logger = new EventLogger();

            var server = ConfigurationManager.AppSettings["Server"];
            var queue = ConfigurationManager.AppSettings["Queue"];

            var bus = ServiceBusFactory.New(sbc =>
                                                {
                                                    sbc.UseRabbitMq();
                                                    sbc.UseRabbitMqRouting();
                                                    sbc.UseControlBus();
                                                    sbc.ReceiveFrom(string.Format("rabbitmq://{0}/{1}", server, queue));
                                                });

            BootstrapLogger();
            
            bus.SubscribeInstance(logger);
        }
    }

    public class EventLogger :  Consumes<AddOrderMessage>.All,
                                Consumes<AddOrderWithMPIDMessage>.All,
                                Consumes<BrokenTradeMessage>.All,
                                Consumes<CrossTradeMessage>.All,
                                Consumes<MarketParticipantPositionMessage>.All,
                                Consumes<NetOrderImbalanceIndicatorMessage>.All,
                                Consumes<OrderCancelMessage>.All,
                                Consumes<OrderDeletedMessage>.All,
                                Consumes<OrderExecutedMessage>.All,
                                Consumes<OrderExecutedWithPriceMessage>.All,
                                Consumes<OrderReplacedMessage>.All,
                                Consumes<RegSHORestrictionMessage>.All,
                                Consumes<StockDirectoryMessage>.All,
                                Consumes<StockTradingActionMessage>.All,
                                Consumes<SystemEventMessage>.All,
                                Consumes<TradeNonCrossMessage>.All,
                                Consumes<SecondMessage>.All
    {

        private readonly ConcurrentDictionary<Type, uint> _msgCounts = new ConcurrentDictionary<Type, uint>();
        private DateTime _startTime = DateTime.Now;
        
        private void HandleMessage(Message msg)
        {
            var msgType = msg.GetType();
            _msgCounts.AddOrUpdate(msgType, 1, (x, y) => y + 1);
        }

        public void Consume(SecondMessage message)
        {
            var now = DateTime.Now;
            var sum = _msgCounts.Sum(x => x.Value);
            Console.WriteLine("Second's worth of data contained {0} msgs, processed in {1} seconds:",
                                sum,
                                (now - _startTime).TotalSeconds);
            foreach (var kv in _msgCounts)
            {
                Console.WriteLine("{0}: {1}", kv.Key.Name, kv.Value);
            }

            _msgCounts.Clear();
            _startTime = now;
        }

        public void Consume(AddOrderMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(AddOrderWithMPIDMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(BrokenTradeMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(CrossTradeMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(MarketParticipantPositionMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(NetOrderImbalanceIndicatorMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(OrderCancelMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(OrderDeletedMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(OrderExecutedMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(OrderExecutedWithPriceMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(OrderReplacedMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(RegSHORestrictionMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(StockDirectoryMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(StockTradingActionMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(SystemEventMessage message)
        {
            HandleMessage(message);
        }

        public void Consume(TradeNonCrossMessage message)
        {
            HandleMessage(message);
        }
    }
}
