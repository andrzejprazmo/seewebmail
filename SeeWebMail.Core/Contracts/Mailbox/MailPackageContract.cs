using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Core.Contracts.Mailbox
{
    public class MailPackageContract
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<MailHeaderContract> List { get; set; }

    }
}
