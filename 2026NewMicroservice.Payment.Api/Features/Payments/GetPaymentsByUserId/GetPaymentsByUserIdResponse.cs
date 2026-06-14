using _2026NewMicroservice.Payment.Api.Repositories;
using System.Globalization;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.GetPaymentsByUserId
{
    public record GetPaymentsByUserIdResponse(Guid Id, string OrderCode, string Amount, DateTime Created, PaymentStatus Status);


}
