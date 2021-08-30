using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SeeWebMail.Core.Mappers;
using SeeWebMail.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Configuration = SeeWebMail.Common.Configuration;
using System.Linq;
using SeeWebMail.Core.Abstract;
using SeeWebMail.Core.Contracts.Mailbox;

namespace SeeWebMail.Core.Services
{
    public class MailboxService : IMailboxService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMailKitRepository mailRepository;
        private readonly ILogger<IMailboxService> logger;
        private readonly Configuration.Mailbox mailboxConfig;

        public MailboxService(ILogger<IMailboxService> logger, IHttpContextAccessor httpContextAccessor, IMailKitRepository mailRepository, IOptions<Configuration.Mailbox> options)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mailRepository = mailRepository;
            this.logger = logger;
            this.mailboxConfig = options.Value;
        }

        public async Task<IEnumerable<FolderContract>> GetFolders()
        {
			try
			{
				var currentUser = UserMapper.FromClaims(httpContextAccessor.HttpContext.User);
                var folders = await mailRepository.GetFolders(currentUser);
                return folders
                    .Select(f => new FolderContract 
                    { 
                        FolderName = f.Name,
                        FolderType = FolderMapper.MapFolderType(f.Name)
                    })
                    .OrderBy(f => f.FolderType)
                    .ToList();
			}
			catch (Exception e)
			{
                logger.LogCritical(e, "ERROR");
                throw;
			}
        }

        public async Task<MailPackageContract> GetMailHeaders(string folderName, int pageNumber)
        {
            try
            {
                var currentUser = UserMapper.FromClaims(httpContextAccessor.HttpContext.User);
                var package = await mailRepository.GetMailHeaders(currentUser, folderName, mailboxConfig.PageSize, pageNumber);
                return new MailPackageContract
                {
                    PageNumber = package.PageNumber,
                    TotalCount = package.TotalCount,
                    List = package.List.Select(m => new MailHeaderContract 
                    { 
                        Index = m.Index,
                        Date = m.Date,
                        Subject = m.Subject,
                        Senders = m.Senders
                    })
                };
            }
            catch (Exception e)
            {
                logger.LogCritical(e, "ERROR");
                throw;
            }
        }

        public async Task<MailBodyContract> GetMailBody(string folderName, int mailIndex)
        {
            try
            {
                var currentUser = UserMapper.FromClaims(httpContextAccessor.HttpContext.User);

                var mailBody = await mailRepository.GetMailBody(currentUser, folderName, mailIndex);
                return new MailBodyContract
                {
                    Index = mailBody.Index,
                    Date = mailBody.Date,
                    Subject = mailBody.Subject,
                    Content = mailBody.Content,
                };
            }
            catch (Exception e)
            {
                logger.LogCritical(e, "ERROR");
                throw;
            }
        }
    }
}
