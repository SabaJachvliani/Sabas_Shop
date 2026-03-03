using Application.Common.Mail;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Infrastucture.Mail
{
    public sealed class SmtpEmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public SmtpEmailSender(IOptions<EmailSettings> options)
            => _settings = options.Value;

        public async Task SendAsync(EmailMessage message, CancellationToken ct = default)
        {
            var mime = new MimeMessage();
            mime.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
            mime.To.Add(MailboxAddress.Parse(message.To));
            mime.Subject = message.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = message.HtmlBody,
                TextBody = message.TextBody
            };
            mime.Body = builder.ToMessageBody();

            using var client = new SmtpClient();

            var secure =
                _settings.UseStartTls ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;

            await client.ConnectAsync(_settings.Host, _settings.Port, secure, ct);
            
            await client.AuthenticateAsync(_settings.User, _settings.Password, ct);

            await client.SendAsync(mime, ct);
            await client.DisconnectAsync(true, ct);
        }
    }
}
