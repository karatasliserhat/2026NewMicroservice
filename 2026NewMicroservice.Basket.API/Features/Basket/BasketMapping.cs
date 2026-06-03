using _2026NewMicroservice.Basket.API.DTOs;
using AutoMapper;

namespace _2026NewMicroservice.Basket.API.Features.Basket
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Data.Basket, BasketDto>().ReverseMap();
             CreateMap<Data.BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
