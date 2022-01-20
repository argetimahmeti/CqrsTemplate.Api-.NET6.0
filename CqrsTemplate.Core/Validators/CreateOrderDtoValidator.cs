using CqrsTemplate.Data.DTO;
using FluentValidation;

namespace CqrsTemplate.Core.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<OrderDTO>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Quatity).NotEqual(0).WithMessage("Quantity should be bigger then zero");
            RuleFor(x => x.Quatity).LessThanOrEqualTo(100).WithMessage("Quantity should be less then 100");
        }
    }
}
