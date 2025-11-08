using RedeSocial.Domain.Entities;

namespace RedeSocial.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<bool> CreatePostAsync(Post post);
        Task DeleteAPostAsync(Post post);
        Task EditAPostAsync(Post post);
    }
}
