using SA.Application.Contracts.Dtos.Product.Product;
using SA.Application.Contracts.Filters.Product.Product;
using SA.Data.Repository.Order.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Product.Product
{
	public interface IProductService
	{
		public Task<IEnumerable<ProductWithImageDto>> GetProductWithImageNoFilter(int size);
		public Task<IEnumerable<ProductPriceDto>> GetProductPriceRange();
		public Task<IEnumerable<ProductWithImageDto>> GetProductWithImageWithFilter(GetProductByCategoryAndPriceRange filter);
		Task<IEnumerable<ProductListDto>> GetProductsList();


	}
}
