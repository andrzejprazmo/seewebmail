using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain.Mail
{
    public class MailHeader
    {
        public int Index { get; set; }
        public string[] Senders { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
    }
}
