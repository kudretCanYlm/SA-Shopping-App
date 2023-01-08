using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Auth;

namespace SA.Data.Repository.Auth.Login
{
	public class LoginRepository:RepositoryBase<LoginEntity,SAContext>, ILoginRepository
	{
		public LoginRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
