using RedeSocial.Domain.Entities;
using RedeSocial.Doman;

namespace RedeSocial.Application.Services.Interfaces
{
    public interface IPostService
    {
        Task<Result<Post>> CreatePostAsync(Post post, CancellationToken cancellationToken);
    }
}
