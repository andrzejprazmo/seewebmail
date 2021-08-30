using SeeWebMail.Core.Contracts.Mailbox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Core.Abstract
{
    public interface IMailboxService
    {
        Task<IEnumerable<FolderContract>> GetFolders();

        Task<MailPackageContract> GetMailHeaders(string folderName, int pageNumber);

        Task<MailBodyContract> GetMailBody(string folderName, int mailIndex);
    }
}
