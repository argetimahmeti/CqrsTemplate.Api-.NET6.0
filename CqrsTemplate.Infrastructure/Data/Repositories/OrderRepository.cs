using CqrsTemplate.Data.Data.Entities;
using CqrsTemplate.Data.Data.Repository;
using CqrsTemplate.Infrastructure.Data.Repositories.Generic;
using CqrsTemplate.Migrations;

namespace CqrsTemplate.Infrastructure.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
