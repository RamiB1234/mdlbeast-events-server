using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace mdlbeast_events_server.Models.EmailEntities
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public FileStreamResult Attachment { get; set; }
        public Message(IEnumerable<string> to, string subject, string content, FileStreamResult attachment = null, string cc = null)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            Subject = subject;
            Content = content;

            if (attachment != null)
            {
                Attachment = attachment;
            }

            Cc = cc;
        }
    }
}
