using SeeWebMail.Common.Const;
using SeeWebMail.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SeeWebMail.Core.Mappers
{
    public static class UserMapper
    {
        public static Credentials FromClaims(ClaimsPrincipal claims)
        {
            return new Credentials
            {
                UserEmail = claims.FindFirstValue(CustomClaimTypes.UserEmail),
                UserPassword = claims.FindFirstValue(CustomClaimTypes.UserPassword),
                Mailbox = new Mailbox
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
