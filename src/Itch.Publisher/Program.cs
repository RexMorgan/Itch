using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using Itch.Common;
using Itch.Common.Messages;
using MassTransit;
using StructureMap;
using Topshelf;

namespace Itch.Publisher
{
    public class Program
    {
        static void Main()
        {
            var server = ConfigurationManager.AppSettings["Server"];
            var queue = ConfigurationManager.AppSettings["Queue"];

            ObjectFactory.Initialize(z => z.For<IServiceBus>()
                                              .Use(() => ServiceBusFactory.New(x =>
                                                                                   {
                                                                                       x.UseRabbitMq();
                                                                                       x.UseRabbitMqRouting();
                                                                                       x.UseControlBus();
                                                                                       x.ReceiveFrom(string.Format("rabbitmq://{0}/{1}", server, queue));
                                                                                   })));
            
            HostFactory.Run(x =>
                                {
                                    x.Service<ItchMessagePublisher>(s =>
                                                                       {
                                                                           s.SetServiceName("ITCH Publisher");
                                                                           s.ConstructUsing(name => new ItchMessagePublisher());
                                                                           s.WhenStarted(p => p.Start());
                                                                           s.WhenStopped(p => p.Stop());
                                                                       });

                                    x.RunAsLocalSystem();

                                    x.SetDescription("ITCH Publisher");
                                    x.SetDisplayName("ITCH Publisher");
                                    x.SetServiceName("ITCH Publisher");
                                });
        }
    }

    public class ItchMessagePublisher
    {
        private readonly IServiceBus _serviceBus;

        public ItchMessagePublisher()
        {
            _serviceBus = ObjectFactory.GetInstance<IServiceBus>();

            var dataFile = ConfigurationManager.AppSettings["DataFile"];
            using (var fs = File.OpenRead(dataFile))
            {
                using (var br = new BinaryReader(fs))
                {
                    var hasData = true;
                    var ptr = 0;
                    const int bufferSize = 1024*4;
                    var dataBuffer = br.ReadBytes(bufferSize);
                    var buflen = dataBuffer.Length;

                    var publishMethod = typeof(PublishExtensions)
                        .GetMethod("Publish", BindingFlags.Public | BindingFlags.Static);
                    var messageCount = 0;

                    while(hasData)
                    {
                        var @byte = dataBuffer[ptr];
                        ptr++;
                        if(ptr == buflen)
                        {
                            // We're out of buffer
                            ptr = 0;
                            dataBuffer = br.ReadBytes(bufferSize);
                            buflen = dataBuffer.Length;
                        }

                        if(@byte == 0x00)
                        {
                            var length = (int)dataBuffer[ptr];
                            ptr++;
                            if((ptr + length) > buflen)
                            {
                                // We don't have the whole message in our buffer
                                var temp = dataBuffer.Slice(ptr, buflen);

                                var byteList = new List<byte>();
                                byteList.AddRange(temp);
                                byteList.AddRange(br.ReadBytes(bufferSize));
                                dataBuffer = byteList.ToArray();

                                buflen = dataBuffer.Length;
                                ptr = 0;
                            }
                            var messageData = dataBuffer.Slice(ptr, ptr + length);
                            ptr = ptr + length;

                            var message = MessageFactory.CreateMessage(messageData);

                            var messageType = message.GetType();

                            messageCount++;

                            if(messageCount % 10000 == 0)
                            {
                                Console.WriteLine("{0} Messages Published!", messageCount);
                            }

                            publishMethod.MakeGenericMethod(messageType)
                                .Invoke(null, new object[] { _serviceBus, message });

                            if(ptr == buflen)
                            {
                                ptr = 0;
                                dataBuffer = br.ReadBytes(bufferSize);
                                buflen = dataBuffer.Length;
                                if(buflen == 0)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Byte was {0}.", (char)@byte);
                        }
                    }

                    Console.WriteLine("Done! {0} Messages Published", messageCount);
                }
            }
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}
