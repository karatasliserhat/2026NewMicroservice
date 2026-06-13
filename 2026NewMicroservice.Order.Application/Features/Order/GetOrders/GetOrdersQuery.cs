using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Order.Application.Features.Order.GetOrders
{
    public record GetOrdersQuery:IRequestServiceResult<List<GetOrderResponse>>;
   
}
