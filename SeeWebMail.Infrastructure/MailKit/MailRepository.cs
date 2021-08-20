using MailKit.Net.Imap;
using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Common;
using SeeWebMail.Contracts.Contracts;
using SeeWebMail.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Infrastructure.MailKit
{
	public class MailRepository : IMailRepository
	{
		public MailRepository()
		{

		}
		public async Task<OperationResult> Authorize(UserContract user, string password)
		{
			try
			{
				using (var imapClient = new ImapClient())
				{
					await imapClient.ConnectAsync(user.Mailbox.ServerName, user.Mailbox.PortNumber, user.Mailbox.UseSsl);
					await imapClient.AuthenticateAsync(user.UserEmail, password);
					return OperationResult.Success;
				}
			}
			catch(ImapCommandException)
			{
				return OperationResult.Create().WithError(ErrorCodes.LoginUserBadPassword);
			}
			catch (Exception)
			{
				return OperationResult.Create().WithError(ErrorCodes.SystemError);
			}
		}
	}
}
