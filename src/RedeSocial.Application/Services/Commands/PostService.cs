using RedeSocial.Application.Services.Interfaces;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Doman;

namespace RedeSocial.Application.Services.Commands
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<Post>> CreatePostAsync(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var post = Post.Create(
                 command.UserId,
                 command.Content,
                 command.PhotoUrl,
                 command.Comment
                 );

            var result = await _postRepository.CreatePostAsync(post);

            if (result)
            {
                return Result<Post>.Success(post);
            }

            return Result<Post>.Failure(new Error("400", ErrorType.BadRequest, "Erro ao fazer a postagem."));
        }
    }
}
