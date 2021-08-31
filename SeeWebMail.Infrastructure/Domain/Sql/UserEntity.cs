using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Domain.Sql
{
	public class UserEntity : MailboxEntity
	{
		public string usr_id { get; set; }
		public string usr_email { get; set; }
		public bool usr_admin { get; set; }

		public User MapToUser() => new User
		{
			UserId = Guid.Parse(usr_id),
			UserEmail = usr_email,
			IsAdmin = usr_admin,
			Mailbox = new Mailbox
			{
				MailboxId = Guid.Parse(mbx_id),
				DomainName = mbx_domain_name,
				ImapAddress = mbx_imap_address,
				ImapPort = mbx_imap_port,
				SmtpAddress = mbx_smtp_address,
				SmtpPort = mbx_smtp_port,
				SmtpSsl = mbx_smtp_ssl,
				ImapSsl = mbx_imap_ssl,
			},
		};
	}
}
