using Application.Exceptions;
using Application.Interfaces;
using Domain.Aggregates.ServiceBookingAggregate.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Services.ServiceProvider
{
    public class SelectProvider
    {
        public record SelectProviderCommand : IRequest
        {
            public List<Guid> ServiceCategoryId { get; set; }
            public DateTime BookingDate { get; set; }
        }

        public class Handler(  IServiceRepository serviceRepository) : IRequestHandler<SelectProviderCommand>
        {
            public async Task Handle(SelectProviderCommand request, CancellationToken cancellationToken)
            {
                var getProvider = await serviceRepository.
               

            }


            private async Task<List<Guid>> AssignServiceProvider(List<Guid> ServiceCategoryId)
            {
                var allServices = await serviceRepository.GetAllAsync();

                var filteredServices = allServices
                    .Where(s => ServiceCategoryId.Contains(s.ServiceCategoryId))
                    .ToList();

                var serviceProviderIds = filteredServices
                    .Select(s => s.ServiceProviderId)
                    .Distinct()
                    .ToList();

                return serviceProviderIds;
            }
        }
    }
}
