using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.Create.CreateService;
using static Application.Commands.CreateCategory;
using static Application.Queries.ViewAllServices;
using static Application.Queries.ViewServiceCategories;

namespace SamkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Create-Service")]
        public async Task<IActionResult> CreateService(CreateServiceCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("Create-ServiceCategory")]
        public async Task<IActionResult> CreateServiceCategory(CreatCategoryCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("Services")]
        public async Task<IActionResult> ViewAllServices()
        {
            var request = new ViewAllServicesCommand();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("Services/Category")]
        public async Task<IActionResult> ViewAllServicesCategory(Guid serviceId)
        {
            var request = new ServiceCategoriesCommand(serviceId);
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
