using MediatR;

namespace NetCore_MediatR.Application.Commands
{
    public class CreateEntityCommand : IRequest<string>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
