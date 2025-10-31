using RedeSocial.Domain.Entities;

namespace RedeSocial.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task MakeAPostAsync(Post post);
        Task DeleteAPostAsync(Post post);
        Task EditAPostAsync(Post post);
    }
}
