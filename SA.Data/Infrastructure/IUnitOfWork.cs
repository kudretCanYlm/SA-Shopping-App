using SA.Data.Context;

namespace SA.Data.Infrastructure
{
	public interface IUnitOfWork<DbContext> where DbContext : Microsoft.EntityFrameworkCore.DbContext, IBaseDbContext
	{
		
		void Commit();
		void BeginTransaction();
		void RollBack();
	}
}
