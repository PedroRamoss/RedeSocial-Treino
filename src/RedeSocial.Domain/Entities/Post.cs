using RedeSocial.Domain.Entities.Aggregates;
using System.Xml.Linq;

namespace RedeSocial.Domain.Entities
{
    public class Post : AggregateRoot, IAuditableEntity
    {
        public Guid UserId { get; private set; }
        public string Content { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static Post Create(Guid userId, string content, string photoUrl, string comment = null)
        {
            var post = new Post()
            {
                UserId = userId,
                Content = content,
                PhotoUrl = photoUrl,
                Comment = comment,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return post;
        }

    }
}
