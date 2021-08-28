using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Contracts
{
	public class CredentialsContract
	{
		public string UserEmail { get; set; }

		public string UserPassword { get; set; }

		public MailboxContract Mailbox { get; set; }
	}
}
