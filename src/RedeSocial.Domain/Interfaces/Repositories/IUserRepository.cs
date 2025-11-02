using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Models;

namespace RedeSocial.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AnyAsync(User user);

        Task<User> GetByUsernameAsync(string username);

        Task CreateAsync(User user);

        Task<User> GetByIdAsync(Guid id);

        Task<bool> UpdateUserAsync(Guid id, UserUpdate user);

    }
}
