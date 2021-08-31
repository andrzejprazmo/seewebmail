using Dapper;
using Microsoft.Data.Sqlite;
using SeeWebMail.Infrastructure.Abstract;
using SeeWebMail.Infrastructure.Domain;
using SeeWebMail.Infrastructure.Domain.Sql;
using SeeWebMail.Infrastructure.Resources.Sql;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Infrastructure.Repositories
{
	public class SqliteRepository : ISqliteRepository
	{
		private readonly string _connectionString;
		public SqliteRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
		public async Task<User> FindUser(string emailAddress)
		{
			using (var connection = new SqliteConnection(_connectionString))
			{
				var user = await connection.QuerySingleOrDefaultAsync<UserEntity>(Queries.GetUsers, new { UserEmail = emailAddress });
				if (user != null)
				{
					return user.MapToUser();
				}
				return null;
			}
		}

		public async Task<Mailbox> FindMailbox(MailAddress emailAddress)
		{
			using (var connection = new SqliteConnection(_connectionString))
			{
				var mailbox = await connection.QuerySingleOrDefaultAsync<MailboxEntity>(Queries.GetMailbox, new { DomainName = emailAddress.Host });
				if (mailbox != null)
				{
					return mailbox.MapToMailbox();
				}
				return null;
			}
		}
	}
}
