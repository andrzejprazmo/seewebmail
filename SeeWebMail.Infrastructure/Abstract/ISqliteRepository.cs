using SeeWebMail.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Infrastructure.Abstract
{
	public interface ISqliteRepository
	{
		Task<User> FindUser(string emailAddress);
	}
}
