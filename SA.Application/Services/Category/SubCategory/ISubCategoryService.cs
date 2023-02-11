using SA.Application.Contracts.Dtos.Category.SubCategory;

namespace SA.Application.Services.Category.SubCategory
{
	public interface ISubCategoryService
	{
		public Task<IEnumerable<SubCategoryWithImageDto>> GetSubCategoriesWithImage();
		public Task<IEnumerable<SubCategoryDto>> GetSubCategories();
		public Task<bool> CreateSubCategory(CreateSubCategoryDto createSubCategoryDto);
	}
}
