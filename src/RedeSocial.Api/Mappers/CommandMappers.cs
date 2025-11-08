using RedeSocial.Api.Controllers.UserControllers.Request;
using RedeSocial.Application.Services.Commands;

namespace RedeSocial.Api.Mappers
{
    internal static class CommandMappers
    {
        internal static CreateUserCommand ToCommand(this CreateUserRequest request)
        {
            return new CreateUserCommand
            {
                ProfilePhotoUrl = request.ProfilePhotoUrl,
                DateOfBirth = request.DateOfBirth,
                DisplayName = request.DisplayName,
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName
            };
        }
    }
}
