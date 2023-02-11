using Microsoft.EntityFrameworkCore;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Category.SubCategory
{
	public class SubCategoryRepository:RepositoryBase<SubCategoryEntity,SAContext>,ISubCategoryRepository
	{
		public SubCategoryRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
