using RedeSocial.Domain.Entities;

namespace RedeSocial.Application.Services.Interfaces
{
    public interface IPostService
    {
        Task<Result> MakeAPostAsync(Post post, CancellationToken cancellationToken);
    }
}
