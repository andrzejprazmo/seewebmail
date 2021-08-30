using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain
{
    public class Credentials
    {
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public Mailbox Mailbox { get; set; }
    }
}
