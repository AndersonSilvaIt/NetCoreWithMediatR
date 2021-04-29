using MediatR;

namespace NetCore_MediatR.Application.Commands
{
    public class DeleteEntityCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
