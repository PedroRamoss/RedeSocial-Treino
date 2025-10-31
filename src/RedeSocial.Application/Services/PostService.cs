using RedeSocial.Application.Services.Interfaces;
using RedeSocial.Domain.Entities;

namespace RedeSocial.Application.Services
{
    public class PostService : IPostService
    {
        public Task<Result> MakeAPostAsync(Post post, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
