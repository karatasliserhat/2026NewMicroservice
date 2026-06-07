namespace _2026NewMicroservice.Discount.API.Features.Discounts.Create
{
    public class CreateDiscountCommandValidator:AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountCommandValidator()
        {
            RuleFor(x=> x.UserId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Code).NotEmpty().WithMessage("{PropertyName} is required.").Length(10).WithMessage("{PropertyName} must be 10 characters long.");
            RuleFor(x => x.Rate).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
