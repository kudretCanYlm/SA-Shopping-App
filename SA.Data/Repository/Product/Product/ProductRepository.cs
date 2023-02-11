using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Product;

namespace SA.Data.Repository.Product.Product
{
	public class ProductRepository : RepositoryBase<ProductEntity, SAContext>, IProductRepository
	{
		public ProductRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	
    }
}
