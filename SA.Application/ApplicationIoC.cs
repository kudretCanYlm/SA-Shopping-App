using Microsoft.Extensions.DependencyInjection;
using SA.Application.Contracts.Dtos.Auth.Login;
using SA.Application.Contracts.Dtos.Category.Category;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using SA.Application.Contracts.Dtos.Product.SallerProduct;
using SA.Application.Services.Auth.Login;
using SA.Application.Services.Category.Category;
using SA.Application.Services.Category.SubCategory;
using SA.Application.Services.Chat.Chat;
using SA.Application.Services.Chat.Message;
using SA.Application.Services.Comment.Comment;
using SA.Application.Services.Comment.CommentReply;
using SA.Application.Services.Location.Address;
using SA.Application.Services.Location.City;
using SA.Application.Services.Location.Country;
using SA.Application.Services.Location.SubCity;
using SA.Application.Services.Media.Image;
using SA.Application.Services.Order.Order;
using SA.Application.Services.Order.OrderDetails;
using SA.Application.Services.Product.Product;
using SA.Application.Services.Product.ProductCategory;
using SA.Application.Services.Product.SallerProduct;
using SA.Application.Services.User.User;
using SA.Application.Services.User.UserDetail;

namespace SA.Application
{
	public static class ApplicationIoC
	{
		public static void SetApplicationIoC(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(ApplicationMapperProfile));
			
			//services
			services.AddScoped<ILoginService,LoginService>();
			
			services.AddScoped<ICategoryService,CategoryService>();
			services.AddScoped<ISubCategoryService,SubCategoryService>();
			
			services.AddScoped<IChatService,ChatService>();
			services.AddScoped<IMessageService,MessageService>();
			
			services.AddScoped<IImageService,ImageService>();
			
			services.AddScoped<IUserService,UserService>();
			services.AddScoped<IUserDetailService,UserDetailService>();
			
			services.AddScoped<ICommentService,CommentService>();
			services.AddScoped<ICommentReplyService, CommentReplyService>();

			services.AddScoped<ICommentReplyService, CommentReplyService>();

			services.AddScoped<IAddressService,AddressService>();
			services.AddScoped<ICityService,CityService>();
			services.AddScoped<ICountryService,CountryService>();
			services.AddScoped<ISubCityService,SubCityService>();
			
			services.AddScoped<IOrderService,OrderService>();
			services.AddScoped<IOrderDetailsService,OrderDetailsService>();
			
			services.AddScoped<IProductService,ProductService>();
			services.AddScoped<IProductCategoryService, ProductCategoryService>();
			services.AddScoped<ISallerProductService, SallerProductService>();

			//Dtos vals
			services.AddScoped<ICreateCategoryDtoValidator, CreateCategoryDtoValidator>();
			services.AddScoped<ICreateSubCategoryDtoValidator, CreateSubCategoryDtoValidator>();
			services.AddScoped<ILoginDtoValidator, LoginDtoValidator>();
			services.AddScoped<ICreateSallerProductDtoValidator, CreateSallerProductDtoValidator>();	
		}
	}
}
