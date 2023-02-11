using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using SA.Application.Contracts.Dtos.Product.Product;
using SA.Application.Contracts.Filters.Product.Product;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Media.Image;
using SA.Data.Repository.Product.Product;
using SA.Data.Repository.Product.ProductCategory;
using SA.Domain.Base;
using SA.Domain.Domains.Product;
using System.Linq;

namespace SA.Application.Services.Product.Product
{
    public class ProductService : IProductService
    {
        private readonly ILogger<LoginService> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork<SAContext> _unitOfWork;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductService(ILogger<LoginService> logger, IMapper mapper, IProductRepository productRepository, IImageRepository imageRepository, IUnitOfWork<SAContext> unitOfWork, IProductCategoryRepository productCategoryRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IEnumerable<ProductPriceDto>> GetProductPriceRange()
        {
            var ProductPriceList = new List<ProductPriceDto>();
            var firstProduct = await _productRepository.GetManyQuery(x => true).OrderBy(x => x.ProductPrice).FirstOrDefaultAsync();
            var lastProduct = await _productRepository.GetManyQuery(x => true).OrderByDescending(x => x.ProductPrice).FirstOrDefaultAsync();

            if (firstProduct == null || lastProduct == null)
                return null;

            var firstPrice = int.Parse(firstProduct.ProductPrice.ToString()) == 0 ? 0 : int.Parse(firstProduct.ProductPrice.ToString());
            var lastPrice = int.Parse(lastProduct.ProductPrice.ToString()) + 500;

            for (int i = firstPrice; i <= lastPrice; i += 100)
            {
                var count=await _productRepository.GetManyQuery(x=>x.ProductPrice>=i && x.ProductPrice<=i+100).CountAsync();
                ProductPriceList.Add(new ProductPriceDto { PriceStart = i, PriceEnd = i + 100,ProductCount=count });
            }
            
            return ProductPriceList;
        }

        public async Task<IEnumerable<ProductWithImageDto>> GetProductWithImageNoFilter(int size)
        {
            var products = await _productRepository.GetManyQuery(x => true).Take(size).ToListAsync();
            var productsWithImages = _mapper.Map<IEnumerable<ProductWithImageDto>>(products);

            foreach (var item in productsWithImages)
            {
                var base64 = await _imageRepository.ProductBase64Single(item.ProductId, 1);
                item.Base64Image = base64;
            }

            return productsWithImages;
        }

        public async Task<IEnumerable<ProductWithImageDto>> GetProductWithImageWithFilter(GetProductByCategoryAndPriceRange filter)
        {

            IQueryable<ProductEntity> productquery;
            if (filter.PriceStart == -1 || filter.PriceEnd == -1)
                productquery = _productRepository.GetManyQuery(x => x.ProductPrice >= filter.PriceStart || x.ProductPrice <= filter.PriceEnd).AsQueryable();
            else
                productquery = _productRepository.GetManyQuery(x => x.ProductPrice >= filter.PriceStart && x.ProductPrice <= filter.PriceEnd).AsQueryable();

            var productCategory = await _productCategoryRepository.GetManyQuery(x => filter.CategoryList.Any(a => a == x.ProductSubCategoryId)).Select(x => new { x.ProductId }).ToListAsync();

            if (!productCategory.Any())
                return null;

            var products = await productquery.Where(x => productCategory.Any(a => a.ProductId == x.Id)).GetPage(filter.Page).ToListAsync();

            if (!products.Any())
                return null;

            var productsWithImages = _mapper.Map<IEnumerable<ProductWithImageDto>>(products);

            foreach (var item in productsWithImages)
            {
                var base64 = await _imageRepository.ProductBase64Single(item.ProductId, 1);
                item.Base64Image = base64;
            }

            return _mapper.Map<IEnumerable<ProductWithImageDto>>(productsWithImages);

        }

        public async Task<IEnumerable<ProductListDto>> GetProductsList()
        {
            var products =_mapper.Map<IEnumerable<ProductListDto>>(await _productRepository.GetAll());
            return products;
        }

    }
}
