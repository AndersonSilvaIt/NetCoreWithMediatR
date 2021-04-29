using MediatR;

namespace NetCore_MediatR.Application.Notifications
{
    public class EntityAlteredNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsEfected { get; set; }
    }
}
