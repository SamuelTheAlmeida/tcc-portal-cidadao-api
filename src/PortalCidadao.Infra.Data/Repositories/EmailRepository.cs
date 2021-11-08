using MailKit.Net.Smtp;
using MimeKit;
using PortalCidadao.Application.Repositories;
using System.Threading.Tasks;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public async Task RedefinirSenha()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Portal Cidadão", "portalcidadaoapp@gmail.com"));
            message.To.Add(new MailboxAddress("Samuel Almeida", "samuel.t.almeida@gmail.com"));
            message.Subject = "Redefinição de senha";

            message.Body = new TextPart("plain")
            {
                Text = @"Teste redefinição senha"
            };

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);

            // Note: only needed if the SMTP server requires authentication
            await client.AuthenticateAsync("portalcidadaoapp@gmail.com", "Cc!azW5Wm_!tXWk");

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
