using System.Text;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace BBQ.MessageBus;

public class AzureServiceBusMessageBus : IMessageBus
{
    private string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    
    public async Task PublishMessage(BaseMessage message, string topicName)
    {
        await using var client = new ServiceBusClient(connectionString);

        ServiceBusSender sender = client.CreateSender(topicName);
        
        var jMessage = JsonConvert.SerializeObject(message);
        ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jMessage))
        {
            CorrelationId = Guid.NewGuid().ToString()
        };
        await sender.SendMessageAsync(finalMessage);
        await client.DisposeAsync();
    }
}