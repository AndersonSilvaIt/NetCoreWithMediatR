using MediatR;

namespace NetCore_MediatR.Application.Notifications
{
    public class EntityCreatedNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
