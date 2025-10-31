using RedeSocial.Api.Controllers.UserControllers.Request;
using RedeSocial.Domain.Entities;

namespace RedeSocial.Api.Mappers
{
    public static class CreateUserRequestMapper
    {
        public static User ToDomain(this CreateUserRequest request)
        {
            return User.Create(
                    request.UserName,
                    request.Email,
                    request.Password,
                    request.DisplayName,
                    request.ProfilePhotoUrl,
                    request.DateOfBirth
                );
        }
    }
}
