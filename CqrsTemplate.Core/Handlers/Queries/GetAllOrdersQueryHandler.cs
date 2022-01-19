using AutoMapper;
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
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDTO>>
    {
    }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var entities = await Task.FromResult(_repository.Order.GetAll());
            return _mapper.Map<IEnumerable<OrderDTO>>(entities);
        }
    }
}
