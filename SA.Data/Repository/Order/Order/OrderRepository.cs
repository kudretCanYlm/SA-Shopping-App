using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Order;

namespace SA.Data.Repository.Order.Order
{
	public class OrderRepository : RepositoryBase<OrderEntity, SAContext>, IOrderRepository
	{
		public OrderRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
