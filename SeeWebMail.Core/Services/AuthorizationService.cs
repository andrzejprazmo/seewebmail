using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Common;
using SeeWebMail.Contracts.Contracts;
using SeeWebMail.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Core.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly ISqliteRepository sqliteRepository;
		public AuthorizationService(ISqliteRepository sqliteRepository)
		{
			this.sqliteRepository = sqliteRepository;
		}

		public async Task<OperationResult<UserContract>> Login(string userEmail, string password)
		{
			try
			{
				var user = await sqliteRepository.GetUser(userEmail);
				if (user != null)
				{
					// TODO authorize in email server

					return OperationResult<UserContract>.Create(user);
				}
				return OperationResult<UserContract>.Create(null).WithError(ErrorCodes.LoginUserNotFound);
			}
			catch (Exception e)
			{
				// logger
				return OperationResult<UserContract>.Create(null).WithError(ErrorCodes.SystemError);
			}
		}
	}
}
