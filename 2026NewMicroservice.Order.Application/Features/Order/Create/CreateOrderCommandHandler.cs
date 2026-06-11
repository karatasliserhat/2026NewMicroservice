using _2026NewMicroservice.Order.Application.Contracts.Repositories;
using _2026NewMicroservice.Order.Application.Contracts.UnitOfWork;
using _2026NewMicroservice.Order.Domain.Entities;
using _2026NewMicroservice.Shared;
using _2026NewMicroservice.Shared.Services;
using MediatR;
using System.Net;

namespace _2026NewMicroservice.Order.Application.Features.Order.Create
{
    internal class CreateOrderCommandHandler(IOrderRepository orderRepository, IIdentityService identityService, IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.Items.Any())
                return ServiceResult.Error("Order Items Not Found", "Order Item Cannot be Null", HttpStatusCode.BadRequest);

            var newAddress = new Address
            {
                Province = request.AddressDto.Province,
                Line = request.AddressDto.Line,
                District = request.AddressDto.District,
                Street = request.AddressDto.Street,
                ZipCode = request.AddressDto.ZipCode
            };

            var order = new Domain.Entities.Order().CreateUnPaidOrder(identityService.GetUserId, request.DiscountRate.Value);

            order.Address = newAddress;

            request.Items.ForEach(x => order.AddOrderItem(x.ProductId, x.ProductName, x.UnitPrice));

            await unitOfWork.CommitAsync(cancellationToken);

            //TODO:Payment işlemleri
            var paymentId = Guid.Empty;
            order.SetPaidStatus(paymentId);


            orderRepository.Update(order);

            await unitOfWork.CommitAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
