using System.Text;
using Azure.Messaging.ServiceBus;
using BBQ.Services.Email.Messages;
using BBQ.Services.Email.Repository;
using Newtonsoft.Json;

namespace BBQ.Services.Email.Messaging;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
{
    private readonly IConfiguration _configuration;

    private readonly EmailRepository _emailRepo;
    private readonly string orderUpdatePaymentResultTopic;
    private readonly string serviceBusConnectionString;
    private readonly string subscriptionEmail;

    private ServiceBusProcessor orderUpdatePaymentStatusProcessor;

    public AzureServiceBusConsumer(EmailRepository emailRepo, IConfiguration configuration)
    {
        _emailRepo = emailRepo;
        _configuration = configuration;

        serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
        subscriptionEmail = _configuration.GetValue<string>("SubscriptionName");
        orderUpdatePaymentResultTopic = _configuration.GetValue<string>("OrderUpdatePaymentResultTopic");


        var client = new ServiceBusClient(serviceBusConnectionString);

        orderUpdatePaymentStatusProcessor = client.CreateProcessor(orderUpdatePaymentResultTopic, subscriptionEmail);
    }

    public async Task Start()
    {
        orderUpdatePaymentStatusProcessor.ProcessMessageAsync += OnOrderPaymentUpdateReceived;
        orderUpdatePaymentStatusProcessor.ProcessErrorAsync += ErrorHandler;
        await orderUpdatePaymentStatusProcessor.StartProcessingAsync();
    }

    public async Task Stop()
    {
        await orderUpdatePaymentStatusProcessor.StopProcessingAsync();
        await orderUpdatePaymentStatusProcessor.DisposeAsync();
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }
    
    private async Task OnOrderPaymentUpdateReceived(ProcessMessageEventArgs args)
    {
        var message = args.Message;
        var body = Encoding.UTF8.GetString(message.Body);

        var objMessage = JsonConvert.DeserializeObject<UpdatePaymentResultMessage>(body);
        await _emailRepo.SendAndLogEmail(objMessage);
        await args.CompleteMessageAsync(args.Message);
    }
}