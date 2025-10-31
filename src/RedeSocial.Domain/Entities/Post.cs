namespace RedeSocial.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public string Content { get; private set; }
        public string? PhotoUrl { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Post(Guid userId, string content, string? photoUrl = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Content = content;
            PhotoUrl = photoUrl;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
