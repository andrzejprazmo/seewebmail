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

		public string SmtpAddress { get; set; }

		public int SmtpPort { get; set; }

		public string Pop3Address { get; set; }

		public int Pop3Port { get; set; }

		public bool UseSsl { get; set; }
	}
}
