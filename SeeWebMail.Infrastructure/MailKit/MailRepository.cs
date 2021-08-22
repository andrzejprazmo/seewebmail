using MailKit.Net.Imap;
using MailKit.Security;
using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Common;
using SeeWebMail.Contracts.Contracts;
using SeeWebMail.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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
					await imapClient.ConnectAsync(user.Mailbox.ImapAddress, user.Mailbox.ImapPort, user.Mailbox.SmtpSsl);
					await imapClient.AuthenticateAsync(user.UserEmail, password);
					return OperationResult.Success;
				}
			}
			catch(AuthenticationException)
			{
				return OperationResult.Create().WithError(ErrorCodes.LoginUserBadPassword);
			}
			catch (Exception)
			{
				return OperationResult.Create().WithError(ErrorCodes.SystemError);
			}
		}

        public async Task<IEnumerable<ImapFolderContract>> GetFolders(UserContract user, string password)
        {
			using (var imapClient = new ImapClient())
			{
				await imapClient.ConnectAsync(user.Mailbox.ImapAddress, user.Mailbox.ImapPort, user.Mailbox.SmtpSsl);
				await imapClient.AuthenticateAsync(user.UserEmail, password);
				var count = imapClient.Inbox.Count;
				var folders = await imapClient.GetFoldersAsync(imapClient.PersonalNamespaces[0]);
				return folders.Select(f => new ImapFolderContract 
				{ 
					FolderName = f.FullName,
				}).ToList();
			}
		}
	}
}
