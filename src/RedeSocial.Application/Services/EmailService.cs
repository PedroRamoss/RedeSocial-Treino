using RedeSocial.Application.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace RedeSocial.Application.Services
{
    public class EmailService : IEmailService
    {
        private const string body = @"
            Olá,

            Obrigado por se cadastrar na RedeSocial! 🎉

            Estamos muito felizes em ter você conosco. A partir de agora, você poderá aproveitar todos os recursos da nossa plataforma para se conectar, compartilhar e descobrir conteúdos incríveis.

            Se tiver qualquer dúvida ou sugestão, nossa equipe está sempre pronta para ajudar.

            Boas conexões,
            Equipe RedeSocial";

        public async Task SendAsync(string email, string message)
        {
            var client = new SmtpClient("live.smtp.mailtrap.io", 587)
            {
                Credentials = new NetworkCredential("api", "Teste"),
                EnableSsl = true
            };

            client.Send("hello@demomailtrap.co", email, "Cadastro", body);
        }
    }
}
