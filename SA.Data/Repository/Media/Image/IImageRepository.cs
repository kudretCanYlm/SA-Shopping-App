using SA.Application.Contracts.Dtos.Media.Image;
using SA.Data.Repository.Base;
using SA.Domain.Base.Enums;
using SA.Domain.Domains.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Media.Image
{
	public interface IImageRepository:IRepository<ImageEntity>
	{
		public IQueryable<ImageEntity> ImageQuery(Guid ownerId, ImageTypesEnum typesEnum = ImageTypesEnum.Category);
		public Task<bool> CreateCategoryImage(CreateImageDto createImageDto);
		public Task<bool> CreateSubCategoryImage(CreateImageDto createImageDto);
		public Task<string> CategoryImageBase64(Guid categoryId);
		public Task<string> SubCategoryImageBase64(Guid subCategoryId);
		public IQueryable<ImageEntity> ProductImageQuery(Guid productId);
		public Task<string> ProductBase64Single(Guid productId,int order);
		public Task<IEnumerable<string>> ProductBase64All(Guid productId);
	}
}
