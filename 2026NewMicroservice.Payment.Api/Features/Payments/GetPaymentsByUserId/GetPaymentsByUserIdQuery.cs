using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.GetPaymentsByUserId
{
    public record GetPaymentsByUserIdQuery:IRequestServiceResult<List<GetPaymentsByUserIdResponse>>;
   
}
