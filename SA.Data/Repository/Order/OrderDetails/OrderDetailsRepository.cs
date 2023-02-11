using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Order;

namespace SA.Data.Repository.Order.OrderDetails
{
	public class OrderDetailsRepository : RepositoryBase<OrderDetailsEntity, SAContext>, IOrderDetailsRepository
	{
		public OrderDetailsRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
