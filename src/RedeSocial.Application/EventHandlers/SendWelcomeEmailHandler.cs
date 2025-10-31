using RedeSocial.Application.Services.Interfaces;
using RedeSocial.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocial.Application.EventHandlers
{
    public class SendWelcomeEmailHandler : IDomainEventHandler<UserCreatedEvent>
    {
        private readonly IEmailService _emailService;

        public SendWelcomeEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task HandleAsync(UserCreatedEvent domainEvent)
        {
            var user = domainEvent.User;
            await _emailService.SendAsync(user.Email, "Mensagem de bem vindo");
        }
    }
}
