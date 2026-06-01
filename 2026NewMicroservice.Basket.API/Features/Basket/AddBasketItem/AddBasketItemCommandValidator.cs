using FluentValidation;

namespace _2026NewMicroservice.Basket.API.Features.Basket.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.CourseName).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
        }
    }
}
