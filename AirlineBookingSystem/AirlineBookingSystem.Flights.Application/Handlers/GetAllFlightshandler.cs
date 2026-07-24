using AirlineBookingSystem.Flights.Application.Queries;
using AirlineBookingSystem.Flights.Core.Entities;
using AirlineBookingSystem.Flights.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Flights.Application.Handlers;

public class GetAllFlightshandler : IRequestHandler<GetAllFlightsQuery, IEnumerable<Flight>>
{
    private readonly IFlightRepository _repository;
    public GetAllFlightshandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetFlightAsync();
    }
}
