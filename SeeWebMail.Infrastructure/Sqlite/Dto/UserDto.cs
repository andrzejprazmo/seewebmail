using SeeWebMail.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Infrastructure.Sqlite.Dto
{
	public class UserDto
	{
		public string usr_id { get; set; }
		public string usr_email { get; set; }
		public string mbx_id { get; set; }
		public string mbx_server { get; set; }
		public int mbx_port { get; set; }

		public UserContract MapToUserContract() => new UserContract 
		{ 
			UserId = Guid.Parse(usr_id),
			UserEmail = usr_email,
			Mailbox = new MailboxContract
			{
				MailboxId = Guid.Parse(mbx_id),
				ServerName = mbx_server,
				PortNumber = mbx_port,
			},
		};
	}
}
