using RedeSocial.Application.Services.Commands;
using RedeSocial.Domain.Entities;
using RedeSocial.Doman;

namespace RedeSocial.Application.Services.Interfaces
{
    public interface IPostService
    {
        Task<Result<Post>> CreatePostAsync(CreatePostCommand post, CancellationToken cancellationToken);
    }
}
