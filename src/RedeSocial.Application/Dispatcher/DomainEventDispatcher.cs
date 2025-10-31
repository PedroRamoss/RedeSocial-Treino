using Microsoft.Extensions.DependencyInjection;
using RedeSocial.Application.EventHandlers;
using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Application.Dispatcher
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    await ((Task)handlerType
                        .GetMethod("HandleAsync")
                        .Invoke(handler, new[] { domainEvent }));
                }
            }
        }

    }
}
