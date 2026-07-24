using AirlineBookingSystem.Flights.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Flights.Infrastructure.Data;

public class FlightContext : IFlightContext
{
    public IMongoCollection<Flight> Flights { get; }

    public FlightContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionStrings"]);
        var dataBase = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        Flights = dataBase.GetCollection<Flight>(configuration["DatabaseSettings:CollectionName"]);
    }
}
