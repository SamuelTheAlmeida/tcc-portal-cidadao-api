using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PortalCidadao.Application.Repositories;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task EsqueciSenha(string nome, string email, Guid tokenRedefinicao)
        {
            var link = $"{_configuration["UrlFrontEnd"]}/redefinir-senha?t={tokenRedefinicao}";

            var caminhoBase = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            var caminho = Path.Combine(Path.Combine(caminhoBase, "TemplatesEmail"), "RedefinirSenha.html");
            
            var template = await File.ReadAllTextAsync(caminho);
            template = template.Replace("{{nome}}", nome);
            template = template.Replace("{{link}}", link);
            template = template.Replace("{{email}}", email);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Portal Cidadão", "portalcidadaoapp@gmail.com"));
            message.To.Add(new MailboxAddress(nome, email));
            message.Subject = "Redefinição de senha";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = template
            };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            client.Connect("smtp-relay.sendinblue.com", 587, false);

            //var senha = "Cc!azW5Wm_!tXWk";
            var senha = "s9YDHUjR52xfA6JS";
            await client.AuthenticateAsync("portalcidadaoapp@gmail.com", senha);
            

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
