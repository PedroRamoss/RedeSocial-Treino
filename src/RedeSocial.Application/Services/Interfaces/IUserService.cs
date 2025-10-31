using RedeSocial.Application.Models;
using RedeSocial.Domain.Entities;


namespace RedeSocial.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<object>> LoginAsync(string username, string password);

        Task<Result<object>> UpdateUserAsync(Guid id, UserUpdateDto user);

        Task<Result> CreateUserAsync(User user);
    }
}
