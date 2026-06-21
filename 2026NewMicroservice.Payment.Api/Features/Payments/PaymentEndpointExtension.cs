
using _2026NewMicroservice.Payment.Api.Features.Payments.Create;
using _2026NewMicroservice.Payment.Api.Features.Payments.GetPaymentsByUserId;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.Payment.Api.Features.Payments
{
    public static class PaymentEndpointExtension
    {
        public static void AddPaymentEndpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/payments")
                .WithTags("Payments")
                .WithApiVersionSet(apiVersionSet)
                .MapCreatePaymentCommandEndpoint()
                .MapGetPaymentsByUserIdQueryEndpoint();
        }
    }
}
