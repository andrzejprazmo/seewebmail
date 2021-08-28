using SeeWebMail.Contracts.Common;
using SeeWebMail.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Contracts.Abstract
{
	public interface IMailRepository
	{
		Task<OperationResult> Authorize(UserContract user, string password);
		Task<IEnumerable<FolderContract>> GetFolders(CredentialsContract credentials);
		Task<IEnumerable<MailMessageHeaderContract>> GetMailHeaders(CredentialsContract credentials, string folderName, int skip = 0, int take = 10);
	}
}
