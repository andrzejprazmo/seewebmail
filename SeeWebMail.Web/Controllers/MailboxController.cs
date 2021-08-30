using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeWebMail.Core.Abstract;
using SeeWebMail.Core.Contracts.Mailbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeWebMail.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MailboxController : ControllerBase
    {
        private readonly IMailboxService mailboxService;
        public MailboxController(IMailboxService mailboxService)
        {
            this.mailboxService = mailboxService;
        }

        [HttpGet]
        [Route("folders")]
        public async Task<IEnumerable<FolderContract>> GetFolders()
        {
            return await mailboxService.GetFolders();
        }

        [HttpGet]
        [Route("headers")]
        public async Task<MailPackageContract> GetMailHeaders(string folderName, int pageNumber = 0)
        {
            return await mailboxService.GetMailHeaders(folderName, pageNumber);
        }

        [HttpGet]
        [Route("body")]
        public async Task<MailBodyContract> GetMailBody(string folderName, int mailIndex)
        {
            return await mailboxService.GetMailBody(folderName, mailIndex);
        }
    }
}
