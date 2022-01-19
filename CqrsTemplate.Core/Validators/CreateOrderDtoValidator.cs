using CqrsTemplate.Data.DTO;
using FluentValidation;

namespace CqrsTemplate.Core.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<OrderDTO>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
