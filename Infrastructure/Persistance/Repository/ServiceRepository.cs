

using System.Linq.Expressions;
using Domain.Aggregates.ServiceBookingAggregate.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository
{
    public class ServiceRepository(SamkaDBContext DbContext) : IServiceRepository
    {
        public async Task<Service> CreateServiceAsync(Service service)
        {
            await DbContext.services.AddAsync(service);
            return service;
        }

        public bool DeleteServiceAsync(Service service)
        {
            DbContext.services.Remove(service);
            return true;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            var getAllServices = await DbContext.services.Include(s => s._services).ToListAsync();
            return getAllServices;
        }

        public async Task<Service?> GetServiceAsync(Expression<Func<Service, bool>> predicate)
        {
            var getService = await DbContext.services.FirstOrDefaultAsync(predicate);
            return getService;
        }

        public async Task<bool> IsExistAsync(Expression<Func<Service, bool>> predicate)
        {
            var getisExist = await DbContext.services.AnyAsync(predicate);
            return getisExist;
        }

        public Service UpdateServiceAsync(Service service)
        {
            DbContext.services.Update(service);
            return service;
        }

        public async Task<Service?> GetServiceByCategory(Expression<Func<Service, bool>> predicate)
        {
            return await DbContext.services.Include(c => c._services).FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Service>> GetAllCategoriesBySeviceAsync(Guid serviceId)
        {
            var getAllServices = await DbContext.services.Include(c => c._services).Where(s => s.Id == serviceId).ToListAsync();
            return getAllServices;
        }

    }
}
