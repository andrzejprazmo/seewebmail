using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Contracts
{
	public class MailboxContract
	{
		public Guid MailboxId { get; set; }

		public string ServerName { get; set; }

		public int PortNumber { get; set; }

		public bool UseSsl { get; set; }
	}
}
