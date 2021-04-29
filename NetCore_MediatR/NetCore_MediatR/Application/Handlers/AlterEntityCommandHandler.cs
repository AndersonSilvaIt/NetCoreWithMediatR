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
    public class AlterEntityCommandHandler : IRequestHandler<AlterEntityCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Entity> _repository;

        public AlterEntityCommandHandler(IMediator mediator, IRepository<Entity> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AlterEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Entity { Id = request.Id, Name = request.Name, Age = request.Age};

            try
            {
                await _repository.Edit(entity);

                await _mediator.Publish(new EntityAlteredNotification { Id = entity.Id, Name = entity.Name, Age = entity.Age, IsEfected = true });

                return await Task.FromResult("Pessoa alterada com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new EntityAlteredNotification { Id = entity.Id, Name = entity.Name, Age = entity.Age, IsEfected = false });
                await _mediator.Publish(new ErroNotification { Exception = ex.Message, QueueError = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }

        }
    }
}
