using SeeWebMail.Common;
using SeeWebMail.Core.Contracts.Authorize;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Core.Abstract
{
	public interface IAuthorizationService
	{
		Task<OperationResult<TokenContract>> Login(string userEmail, string password);
	}
}
