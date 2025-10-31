using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Domain.Events
{
    public class UserUpdatedEvent : IDomainEvent
    {
        public User User { get; }

        public UserUpdatedEvent(User user)
        {
            User = user;
        }
    }
}
