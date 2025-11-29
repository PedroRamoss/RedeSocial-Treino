namespace RedeSocial.Api.Controllers.PostControllers.Request
{
    public class CreatePostRequest
    {
        public string UserId { get; private set; }
        public string Content { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string? Comment { get; set; }
    }
}
