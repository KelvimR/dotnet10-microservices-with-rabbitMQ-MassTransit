using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Notifications.Application.Commands;
using MassTransit;
using MassTransit.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Notifications.Application.Consumers;

public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public PaymentProcessedConsumer(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var paymentProcessedEvent = context.Message;
        var message = $"Payment of ${paymentProcessedEvent.Amount} for Booking Id: {paymentProcessedEvent.BookingId} was processed successfully.";
        var command = new SendNotificationCommand("somene@example.com", message, "Email");
        
        await _publishEndpoint.Publish(command);
    }
}
