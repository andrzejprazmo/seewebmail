using SeeWebMail.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Infrastructure.Abstract
{
	public interface ISqliteRepository
	{
		Task<User> FindUser(string emailAddress);
		Task<Mailbox> FindMailbox(MailAddress emailAddress);
	}
}
