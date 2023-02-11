using Azure;
using SA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Base
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task Add(T entity);
		void Update(T entity);
		void UpdateMany(IEnumerable<T> entities);
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		Task<T> GetById(Guid id);
		Task<T> GetById(string id);
		Task<T> Get(Expression<Func<T, bool>> where);
		Task<IEnumerable<T>> GetAll();
		Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where);
		IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where);
		//IQueryable<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
	}
}
