using AirlineBookingSystem.Bookings.Core.Entities;
using MediatR;
using System.Net;

namespace AirlineBookingSystem.Bookings.Application.Queries;

public record GetBookingQuery(Guid Id) : IRequest<Booking>;