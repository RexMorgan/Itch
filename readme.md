# Itch 4.1 Implementation
This is a C# implementation of the Itch 4.1 protocol decribed here: http://nasdaqtrader.com/content/technicalsupport/specifications/dataproducts/NQTV-ITCH-V4_1.pdf

Please note that this is for educational purposes and probably isn't fast enough to be used in any type of a production environment. I've noticed that I'm able to publish about 3,000 messages/second and consume 1,200 messages per second, which is way too slow to actually use.

For test data, you can download data from past days of trading directly from Nasdaq at: ftp://emi.nasdaq.com/ITCH/

This project is setup as a publisher and a consumer.

## How to Run
Open the solution and run the consumer. You can do this by making sure it's your startup project and hitting F5. Once the consumer is up and running, go back to Visual Studio and right click on the Publisher project. Goto _Debug_, then _Start New Instance_. Let it start up and watch the messages flow.

## Publisher
First and foremost, the code for reading the file was a direct port of the ITCH 4.1 implementation written in python by Ryan Day: https://github.com/rday/ITCH41

This console application reads through the data file defined in the app.config and publishes them to our message queue. It does this as fast as it can. The code can parse about 450k messages/second, however publishing them to the queue reduces the speed to about 3,000/second.

## Consumer
The consumer listens for messages from the queue and keeps track of how many of each type of messages have come in.

For every _SecondMessage_ that we get, we clear out all the counts and print them out to the console. This _SecondMessage_ is sent about every second and marks the number of seconds since midnight.

## Requirements
RabbitMQ is required to be setup. You can point your publisher/consumer to the proper server by editing the Server key in each of the app.config files. However, they are defaulted to _localhost_.