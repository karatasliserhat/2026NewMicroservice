using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.Create
{
    public record CreatePaymentCommand(string OrderCode, string CardNumber, string CardHolderName, string CardExpiration, string CardSecurty, decimal Amount) : IRequestServiceResult<Guid>;

}
