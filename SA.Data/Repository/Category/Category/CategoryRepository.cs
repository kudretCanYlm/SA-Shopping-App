using AutoMapper;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Category;

namespace SA.Data.Repository.Category.Category
{
	public class CategoryRepository:RepositoryBase<CategoryEntity,SAContext>,ICategoryRepository
	{
		private readonly IMapper _mapper;

		public CategoryRepository(IDatabaseFactory<SAContext> databaseFactory, IMapper mapper) :base(databaseFactory)
		{
			_mapper = mapper;
		}
	}
}
