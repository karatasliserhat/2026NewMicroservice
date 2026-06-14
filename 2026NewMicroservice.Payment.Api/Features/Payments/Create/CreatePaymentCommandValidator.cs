using FluentValidation;

namespace _2026NewMicroservice.Payment.Api.Features.Payments.Create
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.OrderCode).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("{PropertyName} grather by zero");
            RuleFor(x => x.CardExpiration).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.CardHolderName).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.CardNumber).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.CardSecurty).NotNull().WithMessage("{PropertyName} is not null");
        }
    }
}
