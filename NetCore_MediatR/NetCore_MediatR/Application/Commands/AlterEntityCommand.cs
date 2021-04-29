using MediatR;

namespace NetCore_MediatR.Application.Commands
{
    public class AlterEntityCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
