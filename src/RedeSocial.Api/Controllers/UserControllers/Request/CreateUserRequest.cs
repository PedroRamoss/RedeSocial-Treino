namespace RedeSocial.Api.Controllers.UserControllers.Request
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePhotoUrl { get; set; }
    }
}
