using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Contracts
{
	public class MailboxContract
	{
		public Guid MailboxId { get; set; }

		public string ImapAddress { get; set; }

		public int ImapPort { get; set; }

		public bool ImapSsl { get; set; }

		public string SmtpAddress { get; set; }

		public int SmtpPort { get; set; }

		public bool SmtpSsl { get; set; }
	}
}
