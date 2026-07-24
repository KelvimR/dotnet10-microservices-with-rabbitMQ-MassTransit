using AirlineBookingSystem.Flights.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Flights.Infrastructure.Data;

public interface IFlightContext
{
    IMongoCollection<Flight> Flights { get; }
}
