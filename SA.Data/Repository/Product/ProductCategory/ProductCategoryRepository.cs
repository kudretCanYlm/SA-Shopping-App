using Microsoft.EntityFrameworkCore;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Product;

namespace SA.Data.Repository.Product.ProductCategory
{
	public class ProductCategoryRepository : RepositoryBase<ProductCategoryEntity, SAContext>,IProductCategoryRepository
	{
		public ProductCategoryRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}

        public async Task<int> CountByCategoryId(Guid id)
        {
            int count=await GetManyQuery(x=>x.ProductSubCategoryId==id).CountAsync();
            return count;
        }
    }
}
