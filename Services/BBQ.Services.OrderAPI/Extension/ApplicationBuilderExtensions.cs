using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using BBQ.Services.OrderAPI.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace BBQ.Services.OrderAPI.Extension;

public static class ApplicationBuilderExtensions
{
    public static IAzureServiceBusConsumer ServiceBusConsumer { get; set; }

    public static IApplicationBuilder UseAzureServiceBusConsumer(this IApplicationBuilder app)
    {
        ServiceBusConsumer = app.ApplicationServices.GetRequiredService<AzureServiceBusConsumer>();
        var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>();

        hostApplicationLife.ApplicationStarted.Register(OnStart);
        hostApplicationLife.ApplicationStopped.Register(OnStop);
        return app;
    }

    private static void OnStart()
    {
        ServiceBusConsumer.Start();
    }

    private static void OnStop()
    {
        ServiceBusConsumer.Stop();
    }
}