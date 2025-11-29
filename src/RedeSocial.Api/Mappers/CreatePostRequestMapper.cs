using RedeSocial.Api.Controllers.PostControllers.Request;
using RedeSocial.Domain.Entities;

namespace RedeSocial.Api.Mappers
{
    public static class CreatePostRequestMapper
    {
        public static Post ToDomain(this CreatePostRequest request)
        {
            return Post.Create(
                Guid.Parse(request.UserId),
                request.Content,
                request.PhotoUrl,
                request.Comment
                );
        }
    }
}
