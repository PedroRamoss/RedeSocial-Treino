namespace RedeSocial.Application.Services.Commands
{
    public class CreatePostCommand
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public string Comment { get; set; }
    }
}
