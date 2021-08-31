using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain.Sql
{
    public class MailboxEntity
    {
		public string mbx_id { get; set; }
        public string mbx_domain_name { get; set; }
        public string mbx_imap_address { get; set; }
		public int mbx_imap_port { get; set; }
		public string mbx_smtp_address { get; set; }
		public int mbx_smtp_port { get; set; }
		public bool mbx_imap_ssl { get; set; }
		public bool mbx_smtp_ssl { get; set; }

		public Mailbox MapToMailbox() => new Mailbox
		{
			MailboxId = Guid.Parse(mbx_id),
			DomainName = mbx_domain_name,
			ImapAddress = mbx_imap_address,
			ImapPort = mbx_imap_port,
			SmtpAddress = mbx_smtp_address,
			SmtpPort = mbx_smtp_port,
			SmtpSsl = mbx_smtp_ssl,
			ImapSsl = mbx_imap_ssl,
		};

	}
}
