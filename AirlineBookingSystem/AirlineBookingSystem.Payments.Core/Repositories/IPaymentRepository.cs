using AirlineBookingSystem.Payments.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Payments.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProccessPaymentAsync(Payment payment);
        Task RefundPaymentAsync(Guid id);
    }
}
