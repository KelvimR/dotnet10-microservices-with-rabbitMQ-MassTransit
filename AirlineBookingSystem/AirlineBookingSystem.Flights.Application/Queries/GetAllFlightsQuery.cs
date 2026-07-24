using AirlineBookingSystem.Flights.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AirlineBookingSystem.Flights.Application.Queries;

public record GetAllFlightsQuery : IRequest<IEnumerable<Flight>>;
