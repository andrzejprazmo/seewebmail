using Dapper;
using Microsoft.Data.Sqlite;
using SeeWebMail.Contracts.Abstract;
using SeeWebMail.Contracts.Contracts;
using SeeWebMail.Infrastructure.Sqlite.Dto;
using SeeWebMail.Infrastructure.Sqlite.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SeeWebMail.Infrastructure.Sqlite
{
	public class SqliteRepository : ISqliteRepository
	{
		private readonly string _connectionString;
		public SqliteRepository(string connectionString)
		{
			_connectionString = connectionString;
		}
		public async Task<UserContract> FindUser(string emailAddress)
		{
			using (var connection = new SqliteConnection(_connectionString))
			{
				var user = await connection.QuerySingleOrDefaultAsync<UserDto>(SqlQueries.GetUsers, new { UserEmail = emailAddress });
				if (user != null)
				{
					return user.MapToUserContract();
				}
				return null;
			}
		}
	}
}
