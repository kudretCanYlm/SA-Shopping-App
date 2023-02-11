using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SA.Application.Contracts.Dtos.Media.Image;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Base.Enums;
using SA.Domain.Domains.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Media.Image
{
	public class ImageRepository:RepositoryBase<ImageEntity,SAContext>, IImageRepository
	{
        private string SingleImageCheckAndReturn(ImageEntity? image)
        {
            if (image == null)
                return "";

            return ImageEntity.ToBase64Image(image);
        }

        private readonly IMapper _mapper;

		public ImageRepository(IDatabaseFactory<SAContext> databaseFactory,IMapper mapper):base(databaseFactory)
		{
            _mapper = mapper;
		}

        public IQueryable<ImageEntity> ImageQuery(Guid ownerId,ImageTypesEnum typesEnum=ImageTypesEnum.Category)
        {
            var query= GetManyQuery(x=>x.ImageOwnerId==ownerId && x.ImageType==typesEnum ).AsQueryable();
            return query;
        }

        public async Task<string> CategoryImageBase64(Guid categoryId)
        {
            var image =await ImageQuery(categoryId).FirstOrDefaultAsync();

            return SingleImageCheckAndReturn(image);

        }

        public IQueryable<ImageEntity> ProductImageQuery(Guid productId)
        {
            var query = GetManyQuery(x => x.ImageOwnerId == productId && x.ImageType == ImageTypesEnum.Product).AsQueryable();
            return query;
        }

        public async Task<string> ProductBase64Single(Guid productId, int order=0)
        {
            var image = await ProductImageQuery(productId).Take(order).FirstOrDefaultAsync();

            return SingleImageCheckAndReturn(image);
        }

        public Task<IEnumerable<string>> ProductBase64All(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCategoryImage(CreateImageDto createImageDto)
        {
            createImageDto.ImageType = ImageTypesEnum.Category;

            var lastImage= GetManyQuery(x=>x.ImageOwnerId==createImageDto.ImageOwnerId).FirstOrDefault();

            if(lastImage!=null)
                Delete(lastImage);

            var image = _mapper.Map<ImageEntity>(createImageDto);

            try
            {
                
                Add(image);

                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

        }

        public Task<bool> CreateSubCategoryImage(CreateImageDto createImageDto)
        {
            createImageDto.ImageType = ImageTypesEnum.SubCategory;

            var lastImage = GetManyQuery(x => x.ImageOwnerId == createImageDto.ImageOwnerId).FirstOrDefault();

            if (lastImage != null)
                Delete(lastImage);

            var image = _mapper.Map<ImageEntity>(createImageDto);

            try
            {

                Add(image);

                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
        }

        public async Task<string> SubCategoryImageBase64(Guid subCategory)
        {
            var image = await ImageQuery(subCategory, ImageTypesEnum.SubCategory).FirstOrDefaultAsync();

            return SingleImageCheckAndReturn(image);
        }


    }
}
