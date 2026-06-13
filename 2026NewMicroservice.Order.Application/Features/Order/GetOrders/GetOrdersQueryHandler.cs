using _2026NewMicroservice.Order.Application.Contracts.Repositories;
using _2026NewMicroservice.Order.Application.Features.Order.CreateOrder;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using AutoMapper;
using MediatR;
using System.Net;

namespace _2026NewMicroservice.Order.Application.Features.Order.GetOrders
{
    public class GetOrdersQueryHandler(IOrderRepository orderRepository, IIdentityService identityService, IMapper mapper) : IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrderResponse>>>
    {
        public async Task<ServiceResult<List<GetOrderResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetOrders(identityService.GetUserId);

            if (!orders.Any())
                return ServiceResult<List<GetOrderResponse>>.Error("Orders Null", $"{identityService.GetUserId} is Orders record 0 find ", HttpStatusCode.NotFound);

            var ordersMap = orders.Select(x => new GetOrderResponse(x.Created, x.TotalPrice, mapper.Map<List<OrderItemDto>>(x.OrderItems))).ToList();

            return ServiceResult<List<GetOrderResponse>>.SuccessAsOk(ordersMap);
        }
    }
}
