

using Application.DTOs;
using Application.Exceptions;
using Domain.Aggregates.ServiceAggregate.Entities;
using Domain.Repositories;
using Domain.Sheared.ValueObjects;
using MediatR;

namespace Application.Commands
{
    public class CreateCategory
    {
        public record CreatCategoryCommand(Guid serviceId, string name, string description, DateTime avgDuration, List<string> serviceCategoryQuestion) : IRequest;

        public class Handler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreatCategoryCommand>
        {
            public async Task Handle(CreatCategoryCommand request, CancellationToken cancellationToken)
            {
                var getCategory = await serviceRepository.GetServiceByCategory(c => c.Id == request.serviceId && c.Name == request.name);
                if (getCategory is not null)
                {
                    throw new DuplicateDataException("Service Category Already Exist");
                }

                var categoryQuestion = new ServiceQuestion( request.serviceCategoryQuestion);
                var newServiceCategory = new ServiceCategory(request.serviceId, request.name, request.description, request.avgDuration, categoryQuestion); ;
                newServiceCategory.AddCategory(newServiceCategory);
                await unitOfWork.Save();
            }
        }
    }
}
