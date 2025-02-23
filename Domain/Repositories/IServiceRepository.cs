

using System.Linq.Expressions;
using Domain.Aggregates.ServiceBookingAggregate.Entities;

namespace Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<Service> CreateServiceAsync(Service service);
        Service UpdateServiceAsync(Service service);
        bool DeleteServiceAsync(Service service);
        Task<Service?> GetServiceAsync(Expression<Func<Service, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<Service, bool>> predicate);
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service?> GetServiceByCategory(Expression<Func<Service, bool>> predicate);
        Task<IEnumerable<Service>> GetAllCategoriesBySeviceAsync(Guid serviceId);
    }
}
