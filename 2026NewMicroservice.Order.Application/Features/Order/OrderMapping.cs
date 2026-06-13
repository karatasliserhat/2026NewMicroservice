using _2026NewMicroservice.Order.Application.Features.Order.CreateOrder;
using _2026NewMicroservice.Order.Domain.Entities;
using AutoMapper;

namespace _2026NewMicroservice.Order.Application.Features.Order
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        }
    }
}
