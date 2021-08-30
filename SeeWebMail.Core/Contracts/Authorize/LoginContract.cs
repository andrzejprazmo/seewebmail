using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Core.Contracts.Authorize
{
	public class LoginContract
	{
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
