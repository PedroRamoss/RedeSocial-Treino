namespace RedeSocial.Domain.Entities.Aggregates
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

    }
}
