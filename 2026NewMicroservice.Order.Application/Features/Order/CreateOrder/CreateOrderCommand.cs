using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Order.Application.Features.Order.CreateOrder
{
    public record CreateOrderCommand(float? DiscountRate, AddressDto AddressDto, PaymentDto PaymentDto,List<OrderItemDto> Items):IRequestServiceResult;
    

    public record AddressDto(string Province, string District, string Street, string ZipCode, string Line);

    public record PaymentDto(string CardNumber, string CardHoldName, string Expiration, string Cvv, decimal Amount);

    public record OrderItemDto(Guid ProductId, string ProductName, decimal UnitPrice);
}
