﻿using MediatR;
using NetCore_MediatR.Application.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore_MediatR.Application.EventHandlers
{
    public class LogEventHandler : 
                                INotificationHandler<EntityCreatedNotification>,
                                INotificationHandler<ErroNotification>
    {
        public Task Handle(EntityCreatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Name} - {notification.Age}");
            });
        }

        /* public Task Handle(PessoaAlteradaNotification notification, CancellationToken cancellationToken)
         {
             return Task.Run(() =>
             {
                 Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo} - {notification.IsEfetivado}'");
             });
         }

         public Task Handle(PessoaExcluidaNotification notification, CancellationToken cancellationToken)
         {
             return Task.Run(() =>
             {
                 Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
             });
         }*/

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Exception} \n {notification.QueueError}'");
            });
        }
    }
}
