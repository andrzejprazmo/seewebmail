using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Core.Contracts.Mailbox
{
    public class MailHeaderContract
    {
        public int Index { get; set; }
        public string[] Senders { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
    }
}
