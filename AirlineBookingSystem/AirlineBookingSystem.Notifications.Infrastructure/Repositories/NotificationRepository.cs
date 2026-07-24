using AirlineBookingSystem.Notifications.Core.Entities;
using AirlineBookingSystem.Notifications.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AirlineBookingSystem.Notifications.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly IDbConnection _dbConnection;
    public NotificationRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task LogNotificaionAsync(Notification notification)
    {
        const string sql = @"
        INSERT INTO Notification (Id, Recipient, Message, Type, SentAt)
        VALUES (@Id, @Recipient, @Message, @Type, @SentAt)";

        await _dbConnection.ExecuteAsync(sql, notification);
    }
}
