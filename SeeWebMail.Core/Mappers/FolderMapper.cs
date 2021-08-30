using SeeWebMail.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Core.Mappers
{
    internal static class FolderMapper
    {
        public static FolderType MapFolderType(string folderName)
        {
            switch (folderName.ToUpper())
            {
                case "INBOX":
                    return FolderType.Inbox;
                case "ARCHIVE":
                    return FolderType.Archive;
                case "DRAFTS":
                    return FolderType.Drafts;
                case "SENT":
                    return FolderType.Sent;
                case "JUNK E-MAIL":
                    return FolderType.Junk;
                case "DELETED ITEMS":
                    return FolderType.Deleted;
                default:
                    return FolderType.Custom;
            }
        }
    }
}
