using RedeSocial.Domain.Entities.Aggregates;
using System.Xml.Linq;

namespace RedeSocial.Domain.Entities
{
    public class Post : AggregateRoot
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public string Content { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string Comment { get; set; }

        public Post(Guid userId, string content, string? photoUrl = null, string comment = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Content = content;
            PhotoUrl = photoUrl;
            CreatedAt = DateTime.UtcNow;
            Comment = comment;
        }
    }
}
