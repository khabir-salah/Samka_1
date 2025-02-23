

using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Queries
{
    public class ViewAllServices
    {
        public record ViewAllServicesCommand : IRequest<ICollection<ViewAllServicesResponse>>;

        public class Handler(IServiceRepository serviceRepository) : IRequestHandler<ViewAllServicesCommand, ICollection<ViewAllServicesResponse>>
        {
            public async Task<ICollection<ViewAllServicesResponse>> Handle(ViewAllServicesCommand request, CancellationToken cancellationToken)
            {
                var getServices = await serviceRepository.GetAllAsync();
                if(getServices == null || !getServices.Any())
                {
                    throw new EmptyDataException("No Service Added At The Moment");
                }

                var services = getServices.Select(x => new ViewAllServicesResponse
                {
                    Description = x.Description,
                    Icon = x.Icon,
                    Name = x.Name,
                    ServiceId = x.Id
                }).ToList();

                return services;
            }
        }

        public record ViewAllServicesResponse
        {
            public string Name { get;  set; } = default!;
            public string Description { get;  set; } = default!;
            public string Icon { get;  set; } = default!;
            public Guid ServiceId { get; set; }
        }
    }
}
