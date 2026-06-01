namespace _2026NewMicroservice.Basket.API.DTOs
{
    public record BasketDto(Guid UserId, List<BasketItemDto> Items)
    {
    }

}
