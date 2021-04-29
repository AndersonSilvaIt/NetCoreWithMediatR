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
    public class DeleteEntityCommandHandler : IRequestHandler<DeleteEntityCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Entity> _repository;

        public DeleteEntityCommandHandler(IMediator mediator, IRepository<Entity> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new EntityDeletedNotification { Id = request.Id, IsEfected = true });

                return await Task.FromResult("Pessoa excluída com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new EntityDeletedNotification { Id = request.Id, IsEfected = false });
                await _mediator.Publish(new ErroNotification { Exception = ex.Message, QueueError = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
