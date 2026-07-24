using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Flights.Application.Handlers;

public class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlightRepository _repository;
    
    public DeleteFlightHandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteFlightAsync(request.Id);
    }
}
