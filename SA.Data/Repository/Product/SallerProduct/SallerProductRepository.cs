using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Product;

namespace SA.Data.Repository.Product.SallerProduct
{
	public class SallerProductRepository:RepositoryBase<SallerProductEntity,SAContext>,ISallerProductRepository
	{
		public SallerProductRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
