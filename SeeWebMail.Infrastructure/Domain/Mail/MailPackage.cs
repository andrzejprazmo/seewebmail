using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain.Mail
{
    public class MailPackage
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<MailHeader> List { get; set; }
    }
}
