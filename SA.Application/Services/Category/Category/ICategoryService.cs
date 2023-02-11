using SA.Application.Contracts.Dtos.Category.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Category.Category
{
	public interface ICategoryService
	{
		public Task<bool> CreateCategory(CreateCategoryDto createCategoryDto);
	}
}
