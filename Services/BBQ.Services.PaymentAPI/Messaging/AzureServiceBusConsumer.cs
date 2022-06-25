using System.Text;
using Azure.Messaging.ServiceBus;
using BBQ.MessageBus;
using BBQ.Services.OrderAPI.Messages;
using BBQ.Services.OrderAPI.Models;
using BBQ.Services.OrderAPI.Repository;
using Newtonsoft.Json;

namespace BBQ.Services.PaymentAPI.Messaging;

public class AzureServiceBusConsumer : IAzureServiceBusConsumer
{
    private readonly string serviceBusConnectionString;
    private readonly string subscriptionCheckout;
    private readonly string checkoutMessageTopic;
    private readonly string orderPaymentProcessTopic;
    
    private readonly OrderRepository _orderRepository;

    private ServiceBusProcessor checkoutProcessor;
    
    private readonly IConfiguration _configuration;
    private readonly IMessageBus _messageBus;
    
    public AzureServiceBusConsumer(OrderRepository orderRepository, IConfiguration configuration, IMessageBus messageBus)
    {
        _orderRepository = orderRepository;
        _configuration = configuration;
        _messageBus = messageBus;

        serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
        subscriptionCheckout = _configuration.GetValue<string>("SubscriptionCheckout");
        checkoutMessageTopic = _configuration.GetValue<string>("CheckoutMessageTopic");
        orderPaymentProcessTopic = _configuration.GetValue<string>("OrderPaymentProcessTopic");

        var client = new ServiceBusClient(serviceBusConnectionString);

        checkoutProcessor = client.CreateProcessor(checkoutMessageTopic, subscriptionCheckout);
    }

    public async Task Start()
    {
        checkoutProcessor.ProcessMessageAsync += OnCheckOutMessageReceived;
        checkoutProcessor.ProcessErrorAsync += OnCheckOutErrorHandler;
        
        await checkoutProcessor.StartProcessingAsync();
    }
    public async Task Stop()
    {
        await checkoutProcessor.StopProcessingAsync();
        await checkoutProcessor.DisposeAsync();
    }

    Task OnCheckOutErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }

    private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
    {
        var message = args.Message;
        var body = Encoding.UTF8.GetString(message.Body);

        CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

        OrderHeader orderHeader = new()
        {
            //TODO configure automapping and add to Program.cs
            
            UserId = checkoutHeaderDto.UserId,
            FirstName = checkoutHeaderDto.FirstName,
            LastName = checkoutHeaderDto.LastName,
            OrderDetails = new List<OrderDetails>(),
            CardNumber = checkoutHeaderDto.CardNumber,
            CouponCode = checkoutHeaderDto.CouponCode,
            CVV = checkoutHeaderDto.CVV,
            DiscountTotal = checkoutHeaderDto.DiscountTotal,
            Email = checkoutHeaderDto.Email,
            ExpiryMonthYear = checkoutHeaderDto.ExpiryMonthYear,
            OrderTime = DateTime.Now,
            OrderTotal = checkoutHeaderDto.OrderTotal,
            PaymentStatus = false,
            Phone = checkoutHeaderDto.Phone,
            PickupDateTime = checkoutHeaderDto.PickupDateTime
        };
        foreach (var detailList in checkoutHeaderDto.CartDetails)
        {
            OrderDetails orderDetails = new()                                     
            {
                ProductId = detailList.ProductId,
                ProductName = detailList.Product.Name,
                Price = detailList.Product.Price,
                Count = detailList.Count
            };
            orderHeader.CartTotalItems += detailList.Count;
            orderHeader.OrderDetails.Add(orderDetails);
        }

        await _orderRepository.AddOrder(orderHeader);

        PaymentRequestMessage paymentRequestMessage = new()
        {
            Name = orderHeader.FirstName + " " + orderHeader.LastName,
            CardNumber = orderHeader.CardNumber,
            CVV = orderHeader.CVV,
            ExpiryMonthYear = orderHeader.ExpiryMonthYear,
            OrderId = orderHeader.OrderHeaderId,
            OrderTotal = orderHeader.OrderTotal
        };
        try
        {
            await _messageBus.PublishMessage(paymentRequestMessage, orderPaymentProcessTopic);
            await args.CompleteMessageAsync(args.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}