using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Basket.API.Features.Basket.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid Id):IRequestServiceResult;
}
