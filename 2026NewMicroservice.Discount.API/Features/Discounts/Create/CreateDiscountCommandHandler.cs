
using _2026NewMicroservice.Discount.API.Repositories;
using System.Net;

namespace _2026NewMicroservice.Discount.API.Features.Discounts.Create
{
    public class CreateDiscountCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateDiscountCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await context.Discounts.AnyAsync(x => x.UserId == request.UserId && x.Code == request.Code, cancellationToken);

            if (discount)
                return ServiceResult.Error("Discount already exists for this user with the same code", HttpStatusCode.BadRequest);

            var discountMap = mapper.Map<Discount>(request);
            discountMap.Created = DateTime.Now;
            discountMap.Expired = DateTime.Now.AddDays(10);

            await context.Discounts.AddAsync(discountMap, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
