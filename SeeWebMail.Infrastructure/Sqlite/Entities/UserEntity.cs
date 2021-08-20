using SeeWebMail.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Sqlite.Dto
{
	public class UserEntity
	{
		public string usr_id { get; set; }
		public string usr_email { get; set; }
		public string mbx_id { get; set; }
		public string mbx_imap_address { get; set; }
		public int mbx_imap_port { get; set; }
		public string mbx_smtp_address { get; set; }
		public int mbx_smtp_port { get; set; }
		public string mbx_pop3_address { get; set; }
		public int mbx_pop3_port { get; set; }
		public bool mbx_use_ssl { get; set; }

		public UserContract MapToUserContract() => new UserContract 
		{ 
			UserId = Guid.Parse(usr_id),
			UserEmail = usr_email,
			Mailbox = new MailboxContract
			{
				MailboxId = Guid.Parse(mbx_id),
				ImapAddress = mbx_imap_address,
				ImapPort = mbx_imap_port,
				SmtpAddress = mbx_smtp_address,
				SmtpPort = mbx_smtp_port,
				Pop3Address = mbx_pop3_address,
				Pop3Port = mbx_pop3_port,
				UseSsl = mbx_use_ssl,
			},
		};
	}
}
