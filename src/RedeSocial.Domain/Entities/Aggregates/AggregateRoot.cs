using RedeSocial.Domain.Events.Interfaces;

namespace RedeSocial.Domain.Entities.Aggregates
{
    public abstract class AggregateRoot : AuditableEntity
    {
        private List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        public Guid Id { get; set; }
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
