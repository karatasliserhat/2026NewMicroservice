using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem
{
    public record AddBasketItemCommand(Guid CourseId, string CourseName, string ImageUrl, decimal Price) : IRequestServiceResult;
}
