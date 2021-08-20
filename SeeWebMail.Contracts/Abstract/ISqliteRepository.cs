using SeeWebMail.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Contracts.Abstract
{
	public interface ISqliteRepository
	{
		Task<UserContract> FindUser(string emailAddress);
	}
}
