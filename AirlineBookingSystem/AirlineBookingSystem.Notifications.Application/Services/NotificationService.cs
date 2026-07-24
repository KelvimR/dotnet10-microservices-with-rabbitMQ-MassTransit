using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Notifications.Application.Services;

public class NotificationService : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
    {
        // Simulate sending notification (via email or sms)
        Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");

    }
}
