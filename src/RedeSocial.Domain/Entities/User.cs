namespace RedeSocial.Domain.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public ICollection<FriendConnection> Friends { get; private set; }
        public ICollection<Post> Posts { get; private set; }
        //public ICollection<ChatMessage> Messages { get; private set; }
    }
}
