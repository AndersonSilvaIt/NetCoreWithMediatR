using MediatR;
using NetCore_MediatR.Application.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore_MediatR.Application.EventHandlers
{
    public class LogEventHandler : 
                                INotificationHandler<EntityCreatedNotification>,
                                INotificationHandler<EntityAlteredNotification>,
                                INotificationHandler<EntityDeletedNotification>,
                                INotificationHandler<ErroNotification>
    {
        public Task Handle(EntityCreatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Name} - {notification.Age}");
            });
        }

         public Task Handle(EntityAlteredNotification notification, CancellationToken cancellationToken)
         {
             return Task.Run(() =>
             {
                 Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.IsEfected}'");
             });
         }

       
         public Task Handle(EntityDeletedNotification notification, CancellationToken cancellationToken)
         {
             return Task.Run(() =>
             {
                 Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfected}'");
             });
         }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Exception} \n {notification.QueueError}'");
            });
        }
    }
}
