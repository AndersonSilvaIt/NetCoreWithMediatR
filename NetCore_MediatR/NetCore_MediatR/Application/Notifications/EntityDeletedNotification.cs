using MediatR;

namespace NetCore_MediatR.Application.Notifications
{
    public class EntityDeletedNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEfected { get; set; }
    }
}
