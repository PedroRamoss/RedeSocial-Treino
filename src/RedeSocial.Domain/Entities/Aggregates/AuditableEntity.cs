namespace RedeSocial.Domain.Entities.Aggregates
{
    public interface IAuditableEntity
    {
        public DateTime CreatedAt { get;  set; }
        public DateTime UpdatedAt { get; set; }

    }
}
