using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }
        public Mailbox Mailbox { get; set; }
    }
}
