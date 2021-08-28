using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Const;
using SeeWebMail.Contracts.Contracts;
using SeeWebMail.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Core.Services
{
    public class MailboxService : IMailboxService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMailRepository mailRepository;
        private readonly ILogger<IMailboxService> logger;

        public MailboxService(ILogger<IMailboxService> logger, IHttpContextAccessor httpContextAccessor, IMailRepository mailRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mailRepository = mailRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<FolderContract>> GetFolders()
        {
			try
			{
				var currentUser = UserMapper.FromClaims(httpContextAccessor.HttpContext.User);

				return await mailRepository.GetFolders(currentUser);
			}
			catch (Exception e)
			{
                logger.LogCritical(e, "ERROR");
                throw;
			}
        }
    }
}
