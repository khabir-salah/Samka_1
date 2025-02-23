

using Application.Exceptions;
using Domain.Repositories;
using Domain.Sheared.ValueObjects;
using MediatR;

namespace Application.Queries
{
    public class ViewServiceCategories
    {
        public record ServiceCategoriesCommand(Guid serviceId) : IRequest<ICollection<ServiceCategoriesResponse>>;

        public class Handler(IServiceRepository serviceRepository) : IRequestHandler<ServiceCategoriesCommand, ICollection<ServiceCategoriesResponse>>
        {
            public async Task<ICollection<ServiceCategoriesResponse>> Handle(ServiceCategoriesCommand request, CancellationToken cancellationToken)
            {
                var getServiceCategories = await serviceRepository.GetAllCategoriesBySeviceAsync(request.serviceId);

                if (getServiceCategories == null || !getServiceCategories.Any())
                {
                    throw new EmptyDataException("No Categories Added At The Moment");
                }

                var categories = getServiceCategories.Select(s => new ServiceCategoriesResponse
                {
                    Name = s._services.First().Name,
                    Description = s._services.First().Description,
                    Price = s._services.First().Price,
                    AvgDuration = s._services.First().AvgDuration,
                    ServiceQuestion = s._services.First().ServiceQuestion,
                }).ToList();

                return categories;
            }
        }

        public record ServiceCategoriesResponse
        {
            public string Name { get;  set; } = default!;
            public string Description { get;  set; } = default!;
            public decimal Price { get; set; }
            public DateTime AvgDuration { get; set; }
            public ServiceQuestion ServiceQuestion { get;  set; }
        }
    }
}
