

namespace _2026NewMicroservice.Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3, 25).WithMessage("{PropertyName} must be 3 and 25 charecters.");
        }
    }
}
