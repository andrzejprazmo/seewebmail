using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Core.Contracts.Mailbox
{
    public class MailBodyContract : MailHeaderContract
    {
        public string Content { get; set; }
    }
}
