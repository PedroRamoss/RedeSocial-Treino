using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Application.Dispatcher
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> events);
    }
}
