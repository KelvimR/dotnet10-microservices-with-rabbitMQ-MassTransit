using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Payments.Application.Commands;

public record class RefundPaymentCommand(Guid PaymentId) : IRequest;
