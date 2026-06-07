
using _2026NewMicroservice.Discount.API.Repositories;
using System.Net;

namespace _2026NewMicroservice.Discount.API.Features.Discounts.GetDiscountByCode
{
    public class GetDiscountByCodeQueryHandler(AppDbContext context) : IRequestHandler<GetDiscountByCodeQuery, ServiceResult<GetDiscountByCodeQueryResponse>>
    {
        public async Task<ServiceResult<GetDiscountByCodeQueryResponse>> Handle(GetDiscountByCodeQuery request, CancellationToken cancellationToken)
        {
            var discount = await context.Discounts.SingleOrDefaultAsync(d => d.Code == request.Code, cancellationToken);

            if (discount is null)
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount not found", HttpStatusCode.NotFound);

            if (discount.Expired < DateTime.UtcNow)
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount is expired", HttpStatusCode.BadRequest);

            var response = new GetDiscountByCodeQueryResponse(discount.Code, discount.Rate);

            return ServiceResult<GetDiscountByCodeQueryResponse>.SuccessAsOk(response);
        }
    }
}
