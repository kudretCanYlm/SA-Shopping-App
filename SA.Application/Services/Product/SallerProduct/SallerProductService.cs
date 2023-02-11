using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SA.Application.Contracts.Dtos.Product.Product;
using SA.Application.Contracts.Dtos.Product.SallerProduct;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Media.Image;
using SA.Data.Repository.Product.SallerProduct;
using SA.Domain.Domains.Product;
using SA.Domain.Domains.Saller;

namespace SA.Application.Services.Product.SallerProduct
{
    public class SallerProductService:ISallerProductService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly ISallerProductRepository _sallerProductRepository;
        private readonly IImageRepository _imageRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;
		private readonly IMapper _mapper;

        public SallerProductService(ILogger<LoginService> logger, ISallerProductRepository sallerProductRepository, IImageRepository imageRepository, IUnitOfWork<SAContext> unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _sallerProductRepository = sallerProductRepository;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddSallerProduct(CreateSallerProductDto createSallerProductDto)
        {
            try
            {
                await _sallerProductRepository.Add(_mapper.Map<SallerProductEntity>(createSallerProductDto));
                await _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                await _unitOfWork.RollBack();
                return false;
            }
        }

        public async Task<IEnumerable<SallerProductDto>> GetSallersProducts(Guid SallerId)
        {
			var productsSaller = await _sallerProductRepository.GetManyQuery(x => x.SallerId== SallerId).Include(x=>x.Product).ToListAsync();
            var productsSallerMapped = _mapper.Map<IEnumerable<SallerProductDto>>(productsSaller);

            return productsSallerMapped;

        }

        public async Task<IEnumerable<ProductWithImageDto>> GetSallersProductsWithImage()
        {
            var productsSaller = await _sallerProductRepository.GetManyQuery(x =>true).Include(x => x.Product).ToListAsync();
            var productsWithImages = _mapper.Map<IEnumerable<ProductWithImageDto>>(productsSaller);
            
            foreach (var item in productsWithImages)
            {
                var base64 = await _imageRepository.ProductBase64Single(item.ProductId, 1);
                item.Base64Image = base64;
            }

            return productsWithImages;
        }
    }
}
