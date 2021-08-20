using SeeWebMail.Contracts.Common;
using SeeWebMail.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Contracts.Abstract
{
	public interface IAuthorizationService
	{
		Task<OperationResult<UserContract>> Login(string userEmail, string password);
	}
}
