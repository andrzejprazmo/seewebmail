using SeeWebMail.Common;
using SeeWebMail.Infrastructure.Domain;
using SeeWebMail.Infrastructure.Domain.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Infrastructure.Abstract
{
	public interface IMailKitRepository
	{
		Task<OperationResult> Authorize(Mailbox mailbox, string userEmail, string password);
		Task<IEnumerable<Folder>> GetFolders(Credentials credentials);
		Task<MailPackage> GetMailHeaders(Credentials credentials, string folderName, int pageSize, int pageNumber = 0);
		Task<MailBody> GetMailBody(Credentials credentials, string folderName, int mailIndex);
	}
}
