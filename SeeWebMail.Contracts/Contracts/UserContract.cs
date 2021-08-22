using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Contracts
{
	public class UserContract
	{
		public Guid UserId { get; set; }
		public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }
        public MailboxContract Mailbox { get; set; }
	}
}
