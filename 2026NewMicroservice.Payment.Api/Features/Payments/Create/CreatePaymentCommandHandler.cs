using _2026NewMicroservice.Payment.Api.Repositories;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using System.Net;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.Create
{
    public class CreatePaymentCommandHandler(AppDbContext context, IIdentityService idenetityService) : IRequestHandler<CreatePaymentCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            (bool isSuccess, string? errorMessage) status = await ExternalPaymentProcess(request.CardNumber, request.CardHolderName, request.CardExpiration, request.CardSecurty);

            if (!status.isSuccess)
                return ServiceResult<Guid>.Error("Payment Faied", "Payment is Faied", HttpStatusCode.BadRequest);

            var payment = new Repositories.Payment(idenetityService.GetUserId, request.OrderCode, request.Amount);

            await context.Payments.AddAsync(payment);

            await context.SaveChangesAsync();

            return ServiceResult<Guid>.SuccessAsOk(payment.Id);

        }

        private async Task<(bool isSuccess, string? errorMessage)> ExternalPaymentProcess(string cardNumber, string cardHolderName, string expiration, string cvv)
        {
            await Task.Delay(1000);

            return (true, null);

            //return (false, "Payment is fail");
        }
    }
}
