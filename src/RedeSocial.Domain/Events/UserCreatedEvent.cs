using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Domain.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public User User { get; }

        public UserCreatedEvent(User user)
        {
            User = user;
        }

    }
}
