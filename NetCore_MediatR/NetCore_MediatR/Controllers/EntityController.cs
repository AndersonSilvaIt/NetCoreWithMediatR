using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCore_MediatR.Application.Commands;
using NetCore_MediatR.Application.Models;
using NetCore_MediatR.Repositories;
using System.Threading.Tasks;

namespace NetCore_MediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Entity> _repository;

        public EntityController(IMediator mediator, IRepository<Entity> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEntityCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
