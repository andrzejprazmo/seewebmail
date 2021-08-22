using SeeWebMail.Contracts.Const;
using SeeWebMail.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SeeWebMail.Core.Mappers
{
    public static class UserMapper
    {
        public static UserContract FromClaims(ClaimsPrincipal claims)
        {
            return new UserContract
            {
                UserEmail = claims.FindFirstValue(CustomClaimTypes.UserEmail),
                Mailbox = new MailboxContract
                {
                    ImapAddress = claims.FindFirstValue(CustomClaimTypes.ImapAddress),
                    ImapPort = int.Parse(claims.FindFirstValue(CustomClaimTypes.ImapPort)),
                    ImapSsl = bool.Parse(claims.FindFirstValue(CustomClaimTypes.ImapSsl)),
                    SmtpAddress = claims.FindFirstValue(CustomClaimTypes.SmtpAddress),
                    SmtpPort = int.Parse(claims.FindFirstValue(CustomClaimTypes.SmtpPort)),
                    SmtpSsl = bool.Parse(claims.FindFirstValue(CustomClaimTypes.SmtpSsl)),
                }
            };
        }
    }
}
