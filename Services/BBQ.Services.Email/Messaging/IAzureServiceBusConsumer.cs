﻿namespace BBQ.Services.Email.Messaging;

public interface IAzureServiceBusConsumer
{
    Task Start();
    Task Stop();
}