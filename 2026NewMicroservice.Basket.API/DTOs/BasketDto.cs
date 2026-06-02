using System.Text.Json.Serialization;

namespace _2026NewMicroservice.Basket.API.DTOs
{
    public record BasketDto
    {
        [JsonIgnore]
        public Guid UserId { get; init; }

        public List<BasketItemDto> Items { get; init; } = new List<BasketItemDto>();

        public BasketDto(Guid userId, List<BasketItemDto> items)
        {
            UserId = userId;
            Items = items;
        }

        public BasketDto()
        {
            
        }
    }

}
