

using Application.Exceptions;
using Domain.Aggregates.ServiceBookingAggregate.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.Create
{
    public class CreateService
    {
        public record CreateServiceCommand(string name, string description, string icon, List<string> locations) : IRequest;

        public class Handler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateServiceCommand>
        {
            public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
            {
                var isCategoryExist = await serviceRepository.IsExistAsync(c => c.Name == request.name);
                if (isCategoryExist)
                {
                    throw new DuplicateDataException("Service Already Exist");
                }

                var newService = new Service(request.name, request.description, request.icon, request.locations);
                await serviceRepository.CreateServiceAsync(newService);
                await unitOfWork.Save();
            }
        }
    }
}
