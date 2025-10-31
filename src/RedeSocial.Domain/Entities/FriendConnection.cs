using RedeSocial.Domain.Enums;

namespace RedeSocial.Domain.Entities
{
    public class FriendConnection
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid FriendId { get; private set; }
        public User Friend { get; private set; }
        public FriendStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public FriendConnection(Guid userId, Guid friendId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            FriendId = friendId;
            Status = FriendStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Accept() => Status = FriendStatus.Accepted;
        public void Block() => Status = FriendStatus.Blocked;
        public void Reject() => Status = FriendStatus.Rejected;
    }
}
