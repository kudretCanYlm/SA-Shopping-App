using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SA.Application.Contracts.Dtos.Category.Category;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using SA.Application.Contracts.Dtos.Media.Image;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Category.SubCategory;
using SA.Data.Repository.Media.Image;
using SA.Data.Repository.Product.Product;
using SA.Data.Repository.Product.ProductCategory;
using SA.Domain.Domains.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Category.SubCategory
{
	public class SubCategoryService:ISubCategoryService
	{
		private readonly IMapper _mapper;
		private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

        public SubCategoryService(IMapper mapper, ISubCategoryRepository subCategoryRepository, IProductCategoryRepository productCategoryRepository, IImageRepository imageRepository, IUnitOfWork<SAContext> unitOfWork)
        {
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSubCategory(CreateSubCategoryDto createSubCategoryDto)
        {
            var subCategory = _mapper.Map<SubCategoryEntity>(createSubCategoryDto);

            var image = new CreateImageDto
            {
                Base64Image = createSubCategoryDto.Base64Image,
                ImageOwnerId = subCategory.Id,
                ImageType = Domain.Base.Enums.ImageTypesEnum.Category
            };

            try
            {

                await _subCategoryRepository.Add(_mapper.Map<SubCategoryEntity>(subCategory));
                await _imageRepository.CreateSubCategoryImage(image);
                await _unitOfWork.Commit();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<SubCategoryDto>> GetSubCategories()
        {
            var categories = await _subCategoryRepository.GetAll();

            return _mapper.Map<IEnumerable<SubCategoryDto>>(categories);
        }

        public async Task<IEnumerable<SubCategoryWithImageDto>> GetSubCategoriesWithImage()
        {
			var categories = await _subCategoryRepository.GetAll();
            var subcategoryWithImages=_mapper.Map<IEnumerable<SubCategoryWithImageDto>>(categories);

            foreach (var item in subcategoryWithImages)
			{
                var base64 =await _imageRepository.SubCategoryImageBase64(item.Id);
                item.Base64Image = base64;
                item.ProductCount = await _productCategoryRepository.CountByCategoryId(item.Id);
            }

            return subcategoryWithImages;
        }


    }
}
