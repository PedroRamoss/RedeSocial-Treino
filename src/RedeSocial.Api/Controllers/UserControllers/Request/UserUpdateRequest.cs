using RedeSocial.Application.Models;

namespace RedeSocial.Api.Controllers.UserControllers.Request
{
    public class UserUpdateRequest
    {
        public string? DisplayName { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? Password { get; set; }

        public static implicit operator UserUpdateDto(UserUpdateRequest request)
            => new()
            {
                DisplayName = request.DisplayName,
                ProfilePhotoUrl = request.ProfilePhotoUrl,
                Password = request.Password
            };
    }
}
