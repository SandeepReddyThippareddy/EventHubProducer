using Azure.Messaging.EventHubs.Producer;
using EventHubProducer;
using System.Text;

var connectionString = "Endpoint=sb://eventhubnamespace212.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=LRBgw9AzvxwBpLEGfT9F8UJWrxSSdzbWj+AEhOlBKWI=;EntityPath=demoeventhub";

EventHubProducerClient producerClient = new EventHubProducerClient(connectionString);

var listOfOrders = new List<Order>() {
    new Order() {
    OrderId= 1,
    Quality= 76,
    UnitPrice = 23
    },
       new Order() {
    OrderId= 2,
    Quality= 76,
    UnitPrice = 23
    },
          new Order() {
    OrderId= 3,
    Quality= 76,
    UnitPrice = 23
    },
             new Order() {
    OrderId= 4,
    Quality= 76,
    UnitPrice = 23
    },
};

EventDataBatch eventDataBatch = producerClient.CreateBatchAsync().GetAwaiter().GetResult();

foreach (var order in listOfOrders)
{
    eventDataBatch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(order.ToString())));
}

producerClient.SendAsync(eventDataBatch).GetAwaiter().GetResult();

Console.WriteLine("Events Sent");

Console.ReadKey();