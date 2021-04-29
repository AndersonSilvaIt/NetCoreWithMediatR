using MediatR;
using NetCore_MediatR.Application.Commands;
using NetCore_MediatR.Application.Models;
using NetCore_MediatR.Application.Notifications;
using NetCore_MediatR.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore_MediatR.Application.Handlers
{
    public class CreateEntityCommandHandler : IRequestHandler<CreateEntityCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Entity> _repository;

        public CreateEntityCommandHandler(IMediator mediator, IRepository<Entity> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Entity { Name = request.Name, Age = request.Age};

            try
            {
                entity = await _repository.Add(entity);

                await _mediator.Publish(new EntityCreatedNotification { Id = entity.Id, Name = entity.Name, Age = entity.Age });

                return await Task.FromResult("Entity Created Success !!!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new EntityCreatedNotification { Id = entity.Id, Name = entity.Name, Age = entity.Age });
                await _mediator.Publish(new ErroNotification { Exception = ex.Message, QueueError = ex.StackTrace });
                return await Task.FromResult("Error ocurr to Created Entity !");
            }
        }
    }
}
