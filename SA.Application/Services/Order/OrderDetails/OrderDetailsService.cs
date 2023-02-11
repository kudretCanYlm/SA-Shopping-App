using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Order.OrderDetails;

namespace SA.Application.Services.Order.OrderDetails
{
	public class OrderDetailsService:IOrderDetailsService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IOrderDetailsRepository _orderDetailsRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public OrderDetailsService(ILogger<LoginService> logger, IOrderDetailsRepository orderDetailsRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_orderDetailsRepository = orderDetailsRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
