using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain.Mail
{
    public class MailBody : MailHeader
    {
        public string Content { get; set; }

    }
}
