using CqrsTemplate.Data.Data.Repository;

namespace CqrsTemplate.Data.Data
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        Task SubmitAsync();
    }
}
