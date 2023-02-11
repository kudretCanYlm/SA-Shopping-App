using Microsoft.Extensions.DependencyInjection;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Auth.Login;
using SA.Data.Repository.Basket.Basket;
using SA.Data.Repository.Category.Category;
using SA.Data.Repository.Category.SubCategory;
using SA.Data.Repository.Chat.Chat;
using SA.Data.Repository.Chat.Message;
using SA.Data.Repository.Comment.Comment;
using SA.Data.Repository.Comment.CommentReply;
using SA.Data.Repository.Location.Address;
using SA.Data.Repository.Location.City;
using SA.Data.Repository.Location.Country;
using SA.Data.Repository.Location.SubCity;
using SA.Data.Repository.Media.Image;
using SA.Data.Repository.Order.Order;
using SA.Data.Repository.Order.OrderDetails;
using SA.Data.Repository.Product.Product;
using SA.Data.Repository.Product.ProductCategory;
using SA.Data.Repository.Product.SallerProduct;
using SA.Data.Repository.Saller.Saller;
using SA.Data.Repository.User.User;
using SA.Data.Repository.User.UserDetail;

namespace SA.Data
{
	public static class DataIoC
	{
		public static void SetDataIoC(this IServiceCollection services)
		{

			services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
			services.AddScoped(typeof(IDatabaseFactory<>), typeof(DatabaseFactory<>));

			//repos
			services.AddScoped<ILoginRepository, LoginRepository>();
			
			services.AddScoped<ICategoryRepository,CategoryRepository>();
			services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
			
			services.AddScoped<IChatRepository, ChatRepository>();
			services.AddScoped<IMessageRepository, MessageRepository>();
			
			services.AddScoped<IImageRepository, ImageRepository>();
			
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserDetailRepository, UserDetailRepository>();
			
			services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<ICommentReplyRepository, CommentReplyRepository>();

			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<ICityRepository, CityRepository>();
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<ISubCityRepository, SubCityRepository>();

			services.AddScoped<IOrderRepository,OrderRepository>();
			services.AddScoped<IOrderDetailsRepository,OrderDetailsRepository>();

			services.AddScoped<IProductRepository,ProductRepository>();
			services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
			services.AddScoped<ISallerProductRepository,SallerProductRepository>();

			services.AddScoped<ISallerRepository, SallerRepository>();

			services.AddScoped<IBasketRepository, BasketRepository>();
			services.AddSingleton<BasketDb>();
			
			//var interfaces=Assembly.GetExecutingAssembly().GetTypes().Where(x=>x.GetInterfaces().Where(x=>x.Name.("I")))

		}
	}
}
