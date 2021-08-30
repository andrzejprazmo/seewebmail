using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Common.Const
{
    public static class CustomClaimTypes
    {
        public static string UserEmail => nameof(UserEmail);
        public static string UserPassword => nameof(UserPassword);
        public static string IsAdmin => nameof(IsAdmin);
        public static string ImapAddress => nameof(ImapAddress);
        public static string ImapPort => nameof(ImapPort);
        public static string ImapSsl => nameof(ImapSsl);
        public static string SmtpAddress => nameof(SmtpAddress);
        public static string SmtpPort => nameof(SmtpPort);
        public static string SmtpSsl => nameof(SmtpSsl);
    }
}
