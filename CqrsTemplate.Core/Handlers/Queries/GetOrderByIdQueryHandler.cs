using AutoMapper;
using CqrsTemplate.Core.Excepitons;
using CqrsTemplate.Data.Data;
using CqrsTemplate.Data.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTemplate.Core.Handlers.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDTO>
    {
        public int OrderId { get; set; }

        public GetOrderByIdQuery(int OrderId)
        {
            this.OrderId = OrderId;
        }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = Task.FromResult(_repository.Order.Get(request.OrderId));

            if(order == null)
            {
                throw new EntityNotFoundException($"No Order found for Id {request.OrderId}");
            }

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
