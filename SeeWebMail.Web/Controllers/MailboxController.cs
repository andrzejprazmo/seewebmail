using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Const;
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
        public async Task<string[]> GetFolders()
        {
            var folders = await mailboxService.GetFolders();
            return folders.Select(f => f.FolderName).ToArray();
        }
    }
}
