using MediatR;

namespace NetCore_MediatR.Application.Notifications
{
    public class ErroNotification : INotification
    {
        public string Exception { get; set; }
        public string QueueError { get; set; }
    }
}
