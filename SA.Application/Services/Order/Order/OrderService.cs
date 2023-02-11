using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Order.Order;

namespace SA.Application.Services.Order.Order
{
	public class OrderService:IOrderService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IOrderRepository _orderRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public OrderService(ILogger<LoginService> logger, IOrderRepository orderRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_orderRepository = orderRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
