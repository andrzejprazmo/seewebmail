using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Enums
{
	public enum ErrorCodes
	{
		SystemError = 100,
		LoginUserNotFound = 101,
		LoginUserBadPassword = 102,
		LoginUserBadCertificate = 103,
	}
}
