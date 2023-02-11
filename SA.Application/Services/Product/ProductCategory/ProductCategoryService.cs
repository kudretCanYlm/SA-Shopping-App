using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Product.ProductCategory;

namespace SA.Application.Services.Product.ProductCategory
{
	public class ProductCategoryService:IProductCategoryService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IProductCategoryRepository _productCategoryRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public ProductCategoryService(ILogger<LoginService> logger, IProductCategoryRepository productCategoryRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_productCategoryRepository = productCategoryRepository;
			_unitOfWork = unitOfWork;
		}

        
    }
}
