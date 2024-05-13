using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using mdlbeast_events_server.Models.EmailEntities;

namespace mdlbeast_events_server.Utilities
{
    public interface IEmailSender
    {

        Task SendEmailAsync(Message message);
    }
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(Message message)
        {
            using (var client = new SmtpClient())
            {
                //Setting TLS 1.2 protocol
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                try
                {
                    var emailMessage = await CreateEmailMessage(message);
                    client.CheckCertificateRevocation = false;
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.Auto);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch (Exception e)
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private async Task<MimeMessage> CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From, _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var builder = new BodyBuilder { HtmlBody = message.Content };

            if (message.Attachment != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await message.Attachment.FileStream.CopyToAsync(memoryStream);

                    builder.Attachments.Add(message.Attachment.FileDownloadName, memoryStream.ToArray(), ContentType.Parse(message.Attachment.ContentType));
                }
            }

            if (!string.IsNullOrEmpty(message.Cc))
            {
                emailMessage.Cc.Add(new MailboxAddress(message.Cc, message.Cc));
            }

            emailMessage.Body = builder.ToMessageBody();

            return emailMessage;
        }
    }
}
