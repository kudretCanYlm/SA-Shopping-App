using SA.Data.Context;

namespace SA.Data.Infrastructure
{
	public interface IUnitOfWork<DbContext> where DbContext : Microsoft.EntityFrameworkCore.DbContext, IBaseDbContext
	{
		
		Task Commit();
		Task BeginTransaction();
		Task RollBack();
	}
}
