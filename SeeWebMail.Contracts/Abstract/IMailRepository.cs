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
		Task<IEnumerable<ImapFolderContract>> GetFolders(UserContract user, string password);
	}
}
