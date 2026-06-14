using _2026NewMicroservice.Payment.Api.Repositories;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.GetPaymentsByUserId
{
    public class GetPaymentsByUserIdQueryHandler(AppDbContext appDbContext, IIdentityService identityService) : IRequestHandler<GetPaymentsByUserIdQuery, ServiceResult<List<GetPaymentsByUserIdResponse>>>
    {
        public async Task<ServiceResult<List<GetPaymentsByUserIdResponse>>> Handle(GetPaymentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userPayments = await appDbContext
                .Payments
                .Where(x => x.UserId == identityService.GetUserId)
                .Select(x =>
                new GetPaymentsByUserIdResponse(
                    x.Id,
                    x.OrderCode,
                    x.Amount.ToString("C"),
                    x.Created,
                    x.Status))
                .ToListAsync();


            return ServiceResult<List<GetPaymentsByUserIdResponse>>.SuccessAsOk(userPayments);


        }
    }
}
