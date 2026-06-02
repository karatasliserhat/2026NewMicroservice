using _2026NewMicroservice.Basket.API.DTOs;
using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Basket.API.Features.Basket.GetBasketByUser
{
    public record GetBasketByUserQuery : IRequestServiceResult<BasketDto>;
}
