using SeeWebMail.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Core.Contracts.Mailbox
{
    public class FolderContract
    {
        public string FolderName { get; set; }
        public FolderType FolderType { get; set; }
    }
}
