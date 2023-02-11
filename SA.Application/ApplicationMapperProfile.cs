using AutoMapper;
using SA.Application.Contracts.Dtos.Auth.Login;
using SA.Application.Contracts.Dtos.Category.Category;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using SA.Application.Contracts.Dtos.Media.Image;
using SA.Application.Contracts.Dtos.Product.Product;
using SA.Application.Contracts.Dtos.Product.SallerProduct;
using SA.Domain.Domains.Auth;
using SA.Domain.Domains.Category;
using SA.Domain.Domains.Media;
using SA.Domain.Domains.Product;

namespace SA.Application
{
	public class ApplicationMapperProfile:Profile
	{
		public ApplicationMapperProfile()
		{
			//Auth
			////Login
			CreateMap<LoginDto, LoginEntity>()
				.ForMember(x => x.Password, act => act.MapFrom(x => LoginEntity.ToHashPassword(x.Password)));
			CreateMap<LoginEntity, LoginJwtDto>();

			//Category
			
			////Category
			CreateMap<CreateCategoryDto, CategoryEntity>();

			////SubCategory
			CreateMap<SubCategoryEntity, SubCategoryWithImageDto>();
			CreateMap<SubCategoryEntity,SubCategoryDto>();
			CreateMap<CreateSubCategoryDto, SubCategoryEntity>();

            //Product
            ////Product
            CreateMap<ProductEntity, ProductWithImageDto>();
			CreateMap<ProductEntity, ProductNoImageDto>();
			CreateMap<ProductEntity, ProductListDto>();


			////Saller
			CreateMap<SallerProductEntity, SallerProductDto>()
				.ForMember(x => x.ProductName, act => act.MapFrom(x => x.Product.ProductName))
				.ForMember(x => x.Price, act => act.MapFrom(x => x.Product.ProductPrice));
			CreateMap<CreateSallerProductDto, SallerProductEntity>();
			CreateMap<SallerProductEntity, ProductWithImageDto>()
				.ForMember(x => x.ProductId, act => act.MapFrom(x => x.Product.Id))
				.ForMember(x => x.ProductName, act => act.MapFrom(x => x.Product.ProductName))
				.ForMember(x => x.Price, act => act.MapFrom(x => x.Product.ProductPrice));

			//Media
			////Image
			CreateMap<CreateImageDto, ImageEntity>()
				.ForMember(x => x.FileExtension, act => act.MapFrom(x => ImageEntity.ToImageFileExtension(x.Base64Image)))
				.ForMember(x => x.ImageData, act => act.MapFrom(x => ImageEntity.ToByteArrayImage(x.Base64Image)));


			
        }
    }
}
