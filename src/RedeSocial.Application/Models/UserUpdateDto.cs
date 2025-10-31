using RedeSocial.Domain.Models;

namespace RedeSocial.Application.Models
{
    public class UserUpdateDto
    {
        public string? DisplayName { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? Password { get; set; }

        public static implicit operator UserUpdate(UserUpdateDto user)
            => new()
            {
                DisplayName = user.DisplayName,
                ProfilePhotoUrl = user.ProfilePhotoUrl,
                Password = user.Password
            };
    }
}
