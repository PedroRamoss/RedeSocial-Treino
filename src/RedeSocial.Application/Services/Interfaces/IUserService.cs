using RedeSocial.Application.Models;
using RedeSocial.Application.Services.Commands;
using RedeSocial.Domain.Entities;
using RedeSocial.Doman;


namespace RedeSocial.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<object>> LoginAsync(string username, string password);

        Task<Result<object>> UpdateUserAsync(Guid id, UserUpdateDto user);

        Task<Result<User>> CreateUserAsync(CreateUserCommand user);
    }
}
