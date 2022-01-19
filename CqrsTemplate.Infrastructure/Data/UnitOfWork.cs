using CqrsTemplate.Data.Data;
using CqrsTemplate.Data.Data.Repository;
using CqrsTemplate.Infrastructure.Data.Repositories;
using CqrsTemplate.Migrations;

namespace CqrsTemplate.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IOrderRepository Order => new OrderRepository(_context);

        public async Task SubmitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
