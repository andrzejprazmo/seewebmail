using Microsoft.AspNetCore.Http;
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

        public MailboxService(IHttpContextAccessor httpContextAccessor, IMailRepository mailRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mailRepository = mailRepository;
        }

        public async Task<IEnumerable<ImapFolderContract>> GetFolders()
        {
            var currentUser = UserMapper.FromClaims(httpContextAccessor.HttpContext.User);
            var password = httpContextAccessor.HttpContext.User.FindFirstValue(CustomClaimTypes.UserPassword);

            return await mailRepository.GetFolders(currentUser, password);

        }
    }
}
