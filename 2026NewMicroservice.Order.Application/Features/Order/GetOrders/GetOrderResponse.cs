using _2026NewMicroservice.Order.Application.Features.Order.CreateOrder;

namespace _2026NewMicroservice.Order.Application.Features.Order.GetOrders
{
    public record GetOrderResponse(DateTime Created, decimal TotolPrice, List<OrderItemDto> Items);

}
