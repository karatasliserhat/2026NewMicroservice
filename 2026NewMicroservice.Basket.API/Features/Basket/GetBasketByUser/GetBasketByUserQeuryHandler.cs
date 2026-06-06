using _2026NewMicroservice.Basket.API.DTOs;
using _2026NewMicroservice.Shared;
using AutoMapper;
using MediatR;
using System.Net;
using System.Text.Json;

namespace _2026NewMicroservice.Basket.API.Features.Basket.GetBasketByUser
{
    public class GetBasketByUserQeuryHandler(IMapper mapper, BasketService basketService) : IRequestHandler<GetBasketByUserQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketByUserQuery request, CancellationToken cancellationToken)
        {
            var basketStringData = await basketService.GetBasketAsync(cancellationToken);
            if (string.IsNullOrEmpty(basketStringData))
                return ServiceResult<BasketDto>.Error("not found", "Not Found basket", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketStringData);
            var basketDto = mapper.Map<BasketDto>(basket);

            return ServiceResult<BasketDto>.SuccessAsOk(basketDto!);
        }
    }
}
