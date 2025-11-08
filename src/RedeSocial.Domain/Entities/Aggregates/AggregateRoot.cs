using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Domain.Entities.Aggregates
{
    public abstract class AggregateRoot : Entity
    {
        private List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected AggregateRoot()
        {
            Id = Guid.NewGuid();
        }

        protected void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvent()
        {
            _domainEvents.Clear();
        }
    }
}
