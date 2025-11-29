using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Application.EventHandlers
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}
