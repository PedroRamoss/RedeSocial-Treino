using RedeSocial.Application.Services.Interfaces;

namespace RedeSocial.Application.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string email, string message)
        {
            await Task.CompletedTask;
        }
    }
}
