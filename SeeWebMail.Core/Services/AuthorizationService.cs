using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SeeWebMail.Common;
using SeeWebMail.Common.Configuration;
using SeeWebMail.Common.Const;
using SeeWebMail.Common.Enums;
using SeeWebMail.Core.Abstract;
using SeeWebMail.Core.Contracts.Authorize;
using SeeWebMail.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Core.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly ISqliteRepository sqliteRepository;
		private readonly IMailKitRepository mailRepository;
		private readonly ILogger<IAuthorizationService> logger;
		private readonly Authorization authorization;
		public AuthorizationService(ILogger<IAuthorizationService> logger
			, ISqliteRepository sqliteRepository
			, IMailKitRepository mailRepository
			, IOptions<Authorization> options)
		{
			this.sqliteRepository = sqliteRepository;
			this.mailRepository = mailRepository;
			this.logger = logger;
			this.authorization = options.Value;
		}

		public async Task<OperationResult<TokenContract>> Login(string userEmail, string password)
		{
			try
			{
				var mailbox = await sqliteRepository.FindMailbox(new MailAddress(userEmail));
				if (mailbox != null)
				{
					var user = await sqliteRepository.FindUser(userEmail);
					var result = await mailRepository.Authorize(mailbox, userEmail, password);
					if (!result.HasErrors)
					{
						var tokenHandler = new JwtSecurityTokenHandler();
						var claims = new List<Claim>
						{
							new Claim(CustomClaimTypes.UserEmail, userEmail),
							new Claim(CustomClaimTypes.UserPassword, password),
							new Claim(CustomClaimTypes.ImapAddress, mailbox.ImapAddress),
							new Claim(CustomClaimTypes.ImapPort, mailbox.ImapPort.ToString()),
							new Claim(CustomClaimTypes.ImapSsl, mailbox.ImapSsl.ToString()),
							new Claim(CustomClaimTypes.SmtpAddress, mailbox.SmtpAddress),
							new Claim(CustomClaimTypes.SmtpPort, mailbox.SmtpPort.ToString()),
							new Claim(CustomClaimTypes.SmtpSsl, mailbox.SmtpSsl.ToString()),
							new Claim(ClaimTypes.Role, user != null ? "ADMIN" : "USER"),
						};
						var tokenDescriptor = new SecurityTokenDescriptor
						{
							Subject = new ClaimsIdentity(claims),
							Expires = DateTime.UtcNow.AddDays(7),
							SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authorization.Secret)), SecurityAlgorithms.HmacSha256Signature)
						};
						var token = tokenHandler.CreateToken(tokenDescriptor);
						return OperationResult<TokenContract>.Create(new TokenContract 
						{ 
							UserEmail = user.UserEmail,
							IsAdmin = user.IsAdmin,
							Token = tokenHandler.WriteToken(token),
						});
					}
					return OperationResult<TokenContract>.Create(null).WithErrors(result.ErrorCodes);
				}
				return OperationResult<TokenContract>.Create(null).WithError(ErrorCodes.LoginUserNotFound);
			}
			catch (Exception e)
			{
				logger.LogCritical(e, "ERROR");
				return OperationResult<TokenContract>.Create(null).WithError(ErrorCodes.SystemError);
			}
		}
	}
}
