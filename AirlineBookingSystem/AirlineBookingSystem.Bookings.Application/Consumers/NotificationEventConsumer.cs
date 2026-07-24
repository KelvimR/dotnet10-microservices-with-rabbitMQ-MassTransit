using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Bookings.Application.Consumers;

public class NotificationEventConsumer : IConsumer<NotificationEvent>
{
    public async Task Consume(ConsumeContext<NotificationEvent> context)
    {
        var notificationEvent = context.Message;

        Console.WriteLine($"Received notification Event: Recipient={notificationEvent.Recipient}, " +
            $"Message={notificationEvent.Message}, Type={notificationEvent.Type}");

        await Task.CompletedTask;
    }
}
