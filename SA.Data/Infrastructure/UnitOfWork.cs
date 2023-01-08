using SA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Infrastructure
{
	public class UnitOfWork<DbContext> : IUnitOfWork<DbContext> where DbContext : Microsoft.EntityFrameworkCore.DbContext, IBaseDbContext
	{
		private readonly IDatabaseFactory<DbContext> databaseFactory;
		private DbContext dbcontext;

		public UnitOfWork(IDatabaseFactory<DbContext> databaseFactory)
		{
			this.databaseFactory = databaseFactory;
		}

		protected DbContext DbContextV
		{
			get { return dbcontext ?? (dbcontext = databaseFactory.Get()); }
		}


		public void BeginTransaction()
		{
			DbContextV.BeginTransaction();
		}

		public void Commit()
		{
			DbContextV.Commit();
		}

		public void RollBack()
		{
			DbContextV.RollBack();
		}
	}
}
