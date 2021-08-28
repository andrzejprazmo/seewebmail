using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Contracts
{
	public class MailMessageHeaderContract
	{
		public string Id { get; set; }
		public string[] Senders { get; set; }
		public string Title { get; set; }
	}
	public class MailMessageContract : MailMessageHeaderContract
	{
		public string Body { get; set; }
	}
}
