using RedeSocial.Application.Services.Interfaces;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Doman;

namespace RedeSocial.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<Post>> CreatePostAsync(Post post, CancellationToken cancellationToken)
        {
            var result = await _postRepository.CreatePostAsync(post);

            if (result)
            {
                return  Result<Post>.Success(post);
            }

            return Result<Post>.Failure(new Error("400", ErrorType.BadRequest, "Erro ao fazer a postagem."));
        }
    }
}
