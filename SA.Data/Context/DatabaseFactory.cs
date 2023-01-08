using Microsoft.EntityFrameworkCore;
using SA.Data.Infrastructure;

namespace SA.Data.Context
{
	public class DatabaseFactory<DbContext>:Disposable,IDatabaseFactory<DbContext> where DbContext:Microsoft.EntityFrameworkCore.DbContext,IBaseDbContext
	{
		private DbContext dbContext;

		public DatabaseFactory(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public DbContext Get()
		{
			return dbContext ;
		}
		protected override void DisposeCore()
		{
			if (dbContext != null)
				dbContext.Dispose();
		}
	}
}
