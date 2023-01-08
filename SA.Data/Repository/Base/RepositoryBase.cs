using Microsoft.EntityFrameworkCore;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Domain.Base;
using System.Linq.Expressions;

namespace SA.Data.Repository.Base
{
	public class RepositoryBase<T,DbContext> where T : BaseEntity 
											 where DbContext : Microsoft.EntityFrameworkCore.DbContext, IBaseDbContext
	{

		private DbContext dbContext;
		private readonly DbSet<T> dbSet;

		protected RepositoryBase(IDatabaseFactory<DbContext> databaseFactory)
		{
			DatabaseFactory = databaseFactory;
			dbSet = DbContextV.Set<T>();
		}

		protected IDatabaseFactory<DbContext> DatabaseFactory
		{
			get;
			private set;
		}

		protected DbContext DbContextV
		{
			get { return dbContext ?? (dbContext = DatabaseFactory.Get()); }
		}

		public virtual void Add(T entity)
		{
			dbSet.Add(entity);
		}
		public virtual void Update(T entity)
		{
			dbSet.Attach(entity);
			DbContextV.Entry(entity).State = EntityState.Modified;
		}

		public virtual void UpdateMany(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				dbSet.Attach(entity);
				DbContextV.Entry(entity).State = EntityState.Modified;
			}
		}

		public virtual void Delete(T entity)
		{
			dbSet.Remove(entity);
		}
		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
				dbSet.Remove(obj);
		}
		public virtual T GetById(Guid id)
		{
			return dbSet.Find(id);
		}
		public virtual T GetById(string id)
		{
			return dbSet.Find(id);
		}
		public virtual IEnumerable<T> GetAll()
		{
			return dbSet.ToList();
		}

		public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where).ToList();
		}

		public virtual IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where);
		}



		/// <summary>
		/// Return a paged list of entities
		/// </summary>
		/// <typeparam name="TOrder"></typeparam>
		/// <param name="page">Which page to retrieve</param>
		/// <param name="where">Where clause to apply</param>
		/// <param name="order">Order by to apply</param>
		/// <returns></returns>
		//public virtual IQueryable<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
		//{
		//	var result = dbset.OrderBy(order).Where(where).GetPage(page);
		//	return result;
		//}

		public T Get(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(where).FirstOrDefault<T>();
		}

	}
}
