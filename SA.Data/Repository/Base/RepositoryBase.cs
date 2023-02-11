using Microsoft.EntityFrameworkCore;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Domain.Base;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

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

		public virtual async Task Add(T entity)
		{
			entity.CreatedAt= DateTime.Now;
			await dbSet.AddAsync(entity);
		}
		public virtual void Update(T entity)
		{
			entity.ModifiedAt = DateTime.Now;
			dbSet.Attach(entity);
			DbContextV.Entry(entity).State = EntityState.Modified;
		}

		public virtual void UpdateMany(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
                entity.ModifiedAt = DateTime.Now;
                dbSet.Attach(entity);
				DbContextV.Entry(entity).State = EntityState.Modified;
			}
		}

		public virtual void Delete(T entity)
		{
            entity.DeletedAt = DateTime.Now;
			entity.isDeleted = true;
            dbSet.Attach(entity);
            DbContextV.Entry(entity).State = EntityState.Modified;
        }
		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
			{
                obj.DeletedAt = DateTime.Now;
				obj.isDeleted= true;
                dbSet.Attach(obj);
                DbContextV.Entry(obj).State = EntityState.Modified;
            }
		}
		public virtual async Task<T> GetById(Guid id)
		{
			return await dbSet.Where(x => x.isDeleted == false && x.Id==id).FirstOrDefaultAsync();
		}
		public virtual async Task<T> GetById(string id)
		{
			return await dbSet.FindAsync(id);
		}
		public virtual async Task<IEnumerable<T>> GetAll()
		{
			return await dbSet.Where(x => x.isDeleted == false).ToListAsync();
		}

		public virtual async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where)
		{
			return await dbSet.Where(x => x.isDeleted == false).Where(where).ToListAsync();
		}

		public virtual IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where)
		{
			return dbSet.Where(x=>x.isDeleted==false).Where(where);
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

		public async Task<T> Get(Expression<Func<T, bool>> where)
		{
			return await dbSet.Where(where).FirstOrDefaultAsync<T>();
		}

	}
}
