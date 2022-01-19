using CqrsTemplate.Core.Excepitons;
using CqrsTemplate.Data.Data;
using CqrsTemplate.Data.Data.Entities;
using CqrsTemplate.Data.DTO;
using FluentValidation;
using MediatR;

namespace CqrsTemplate.Core.Handlers.Commands
{

    public class CreateOrderCommand : IRequest<int>
    {
        public OrderDTO Model { get; }
        public CreateOrderCommand(OrderDTO model)
        {
            this.Model = model;
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<OrderDTO> _validator;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IValidator<OrderDTO> validator)
        {
            _repository = unitOfWork;
            _validator = validator;
        }

        public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            OrderDTO model = command.Model;

            var result = _validator.Validate(model);

            if(!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }

            var entity = new Order
            {
                Name = model.Name,
                Description = model.Description,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified,
                Quatity = model.Quatity,
            };

            _repository.Order.Add(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }

    }
}
