using System.Text;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BBQ.MessageBus;

public class AzureServiceBusMessageBus : IMessageBus
{
    private readonly IConfiguration Configuration;
    private string connectionString;
    public AzureServiceBusMessageBus(IConfiguration configuration)
    {
        Configuration = configuration;
        connectionString = configuration.GetConnectionString("CONNECTION_STRING");
    }

    
    
    public async Task PublishMessage(BaseMessage message, string topicName)
    {
        Console.WriteLine(connectionString);

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