using FluentValidation;

namespace _2026NewMicroservice.Order.Application.Features.Order.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.DiscountRate).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is 0 and 100");

            RuleFor(x => x.AddressDto).NotNull().WithMessage("{PropertyName} is not null")
                .SetValidator(new AddressDtoValidator());

            RuleFor(x => x.Items).NotNull().WithMessage("{PropertyName} is not null");

            RuleForEach(x => x.Items).SetValidator(new OrderItemDtoValidator());

            RuleFor(x => x.PaymentDto).NotNull().WithMessage("{PropertyName} is not null")
                 .SetValidator(new PaymentDtoValidator());
        }
    }

    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {

        public AddressDtoValidator()
        {
            RuleFor(x => x.District).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Province).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Line).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Street).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.ZipCode).NotNull().WithMessage("{PropertyName} is not null");
        }
    }

    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {

        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.ProductName).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("{PropertyName} must be grather then zero");
        }
    }


    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {

        public PaymentDtoValidator()
        {
            RuleFor(x => x.CardNumber).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.CardHoldName).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Expiration).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Cvv).NotNull().WithMessage("{PropertyName} is not null");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("{PropertyName} must be grather then zero");
        }
    }
}
