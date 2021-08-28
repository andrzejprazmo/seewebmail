using MailKit;
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
					imapClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
					await imapClient.ConnectAsync(user.Mailbox.ImapAddress, user.Mailbox.ImapPort, user.Mailbox.SmtpSsl);
					await imapClient.AuthenticateAsync(user.UserEmail, password);
					return OperationResult.Success;
				}
			}
			catch(AuthenticationException)
			{
				return OperationResult.Create().WithError(ErrorCodes.LoginUserBadPassword);
			}
			catch(SslHandshakeException)
			{
				return OperationResult.Create().WithError(ErrorCodes.LoginUserBadCertificate);
			}
			catch (Exception)
			{
				return OperationResult.Create().WithError(ErrorCodes.SystemError);
			}
		}

        public async Task<IEnumerable<FolderContract>> GetFolders(CredentialsContract credentials)
        {
			using (var imapClient = new ImapClient())
			{
				imapClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
				await imapClient.ConnectAsync(credentials.Mailbox.ImapAddress, credentials.Mailbox.ImapPort, credentials.Mailbox.SmtpSsl);
				await imapClient.AuthenticateAsync(credentials.UserEmail, credentials.UserPassword);
				var folders = await imapClient.GetFoldersAsync(imapClient.PersonalNamespaces[0]);
				return folders.Select(f => new FolderContract
				{
					FolderId = f.Id,
					FolderName = f.FullName,
				}).ToList();
			}
		}

		public async Task<IEnumerable<MailMessageHeaderContract>> GetMailHeaders(CredentialsContract credentials, string folderName, int skip = 0, int take = 10)
		{
			using (var imapClient = new ImapClient())
			{
				imapClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
				await imapClient.ConnectAsync(credentials.Mailbox.ImapAddress, credentials.Mailbox.ImapPort, credentials.Mailbox.SmtpSsl);
				await imapClient.AuthenticateAsync(credentials.UserEmail, credentials.UserPassword);
				var folder = await imapClient.GetFolderAsync(folderName);
				if (folder != null)
				{
					var list = folder.Select(mm => new MailMessageHeaderContract 
					{ 
						Id = mm.MessageId,
						Senders = mm.From.Select(s=>s.Name).ToArray(),
						Title = mm.Subject,
					}).SkipLast(skip)
					.TakeLast(take)
					.ToList();
					await folder.CloseAsync();
					return list;
				}
				throw new Exception($"Cannot open folder {folderName}");
			}
		}
	}
}
