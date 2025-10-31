using RedeSocial.Domain.Entities.Aggregates;
using RedeSocial.Domain.Events;

namespace RedeSocial.Domain.Entities
{
    public class User : AggregateRoot
    {
        public User()
        {
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string DisplayName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string ProfilePhotoUrl { get; private set; }
        public ICollection<FriendConnection> Friends { get; private set; }
        public ICollection<Post> Posts { get; private set; }

        //public ICollection<ChatMessage> Messages { get; private set; }
        public static User Create(
        string userName,
        string email,
        string password,
        string displayName,
        string? profilePhotoUrl,
        DateTime dateOfBirth)
        {
            var user = new User
            {
                UserName = userName,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                DisplayName = displayName,
                ProfilePhotoUrl = profilePhotoUrl ?? string.Empty,
                DateOfBirth = dateOfBirth
            };

            user.AddDomainEvent(new UserCreatedEvent(user));
            return user;
        }

        public void UpdatedProfile(string displayName, string photoUrl)
        {
            DisplayName = displayName;
            ProfilePhotoUrl = photoUrl;
            AddDomainEvent(new UserUpdatedEvent(this));
        }
    }
}
