using Microsoft.Extensions.Logging;
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
		private readonly IMailRepository mailRepository;
		private readonly ILogger<IAuthorizationService> logger;
		public AuthorizationService(ILogger<IAuthorizationService> logger, ISqliteRepository sqliteRepository, IMailRepository mailRepository)
		{
			this.sqliteRepository = sqliteRepository;
			this.mailRepository = mailRepository;
			this.logger = logger;
		}

		public async Task<OperationResult<UserContract>> Login(string userEmail, string password)
		{
			try
			{
				var user = await sqliteRepository.FindUser(userEmail);
				if (user != null)
				{
					var result = await mailRepository.Authorize(user, password);
					if (result.HasErrors)
					{
						return OperationResult<UserContract>.Create(null).WithErrors(result.ErrorCodes);
					}
					return OperationResult<UserContract>.Create(user);
				}
				return OperationResult<UserContract>.Create(null).WithError(ErrorCodes.LoginUserNotFound);
			}
			catch (Exception e)
			{
				logger.LogCritical(e, "ERROR");
				return OperationResult<UserContract>.Create(null).WithError(ErrorCodes.SystemError);
			}
		}
	}
}
