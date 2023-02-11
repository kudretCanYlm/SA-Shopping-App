﻿using Azure;
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
		void Add(T entity);
		void Update(T entity);
		void UpdateMany(IEnumerable<T> entities);
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		T GetById(Guid id);
		T GetById(string id);
		T Get(Expression<Func<T, bool>> where);
		IEnumerable<T> GetAll();
		IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
		IQueryable<T> GetManyQuery(Expression<Func<T, bool>> where);
		//IQueryable<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
	}
}