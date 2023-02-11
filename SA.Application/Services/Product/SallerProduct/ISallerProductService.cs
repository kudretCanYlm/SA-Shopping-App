using SA.Application.Contracts.Dtos.Product.Product;
using SA.Application.Contracts.Dtos.Product.SallerProduct;
using SA.Data.Repository.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Product.SallerProduct
{
    public interface ISallerProductService
	{
		public Task<IEnumerable<SallerProductDto>> GetSallersProducts(Guid SallerId);
		public Task<IEnumerable<ProductWithImageDto>> GetSallersProductsWithImage();

		public Task<bool> AddSallerProduct(CreateSallerProductDto createSallerProductDto);
	}
}
