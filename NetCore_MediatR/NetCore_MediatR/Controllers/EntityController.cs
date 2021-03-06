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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEntityCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlterEntityCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeleteEntityCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}
