namespace RedeSocial.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string email, string message);
    }
}
