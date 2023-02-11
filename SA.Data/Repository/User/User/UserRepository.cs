using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.User.User
{
	public class UserRepository:RepositoryBase<UserEntity,SAContext>,IUserRepository
	{
		public UserRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
