using AutoMapper;
using SA.Application.Contracts.Dtos.Category.Category;
using SA.Application.Contracts.Dtos.Media.Image;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Category.Category;
using SA.Data.Repository.Media.Image;
using SA.Domain.Domains.Category;

namespace SA.Application.Services.Category.Category
{
	public class CategoryService:ICategoryService
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository, IImageRepository imageRepository, IUnitOfWork<SAContext> unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //is there control
            var category = _mapper.Map<CategoryEntity>(createCategoryDto);

            var image = new CreateImageDto
            {
                Base64Image=createCategoryDto.Base64Image,
                ImageOwnerId=category.Id,
                ImageType=Domain.Base.Enums.ImageTypesEnum.Category
            };

            try
            {
                
                await _categoryRepository.Add(_mapper.Map<CategoryEntity>(category));
                await _imageRepository.CreateCategoryImage(image);
                await _unitOfWork.Commit();

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
    }
}
