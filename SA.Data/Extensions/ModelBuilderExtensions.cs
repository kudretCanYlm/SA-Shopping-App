using Microsoft.EntityFrameworkCore;
using SA.Domain.Domains.Auth;
using SA.Domain.Domains.Category;
using SA.Domain.Domains.Chat;
using SA.Domain.Domains.Comment;
using SA.Domain.Domains.Location;
using SA.Domain.Domains.Media;
using SA.Domain.Domains.Order;
using SA.Domain.Domains.Product;
using SA.Domain.Domains.Saller;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Extensions
{
	public static class ModelBuilderExtensions
	{
		public static void OnModelCreatingInit(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LoginEntity>().ToTable("Login");
			modelBuilder.Entity<CategoryEntity>().ToTable("Category");
			modelBuilder.Entity<SubCategoryEntity>().ToTable("SubCategory");
			modelBuilder.Entity<ChatEntity>().ToTable("Chat");
			modelBuilder.Entity<MessageEntity>().ToTable("Message");
			modelBuilder.Entity<ImageEntity>().ToTable("Image");
			modelBuilder.Entity<UserEntity>().ToTable("User");
			modelBuilder.Entity<UserDetailEntity>().ToTable("UserDetail");
			modelBuilder.Entity<CommentEntity>().ToTable("Comment");
			modelBuilder.Entity<CommentReplyEntity>().ToTable("CommentReply");
			modelBuilder.Entity<AddressEntity>().ToTable("Address");
			modelBuilder.Entity<CityEntity>().ToTable("City");
			modelBuilder.Entity<CountryEntity>().ToTable("Country");
			modelBuilder.Entity<OrderDetailsEntity>().ToTable("OrderDetails");
			modelBuilder.Entity<OrderEntity>().ToTable("Order");
			modelBuilder.Entity<ProductCategoryEntity>().ToTable("ProductCategory");
			modelBuilder.Entity<ProductEntity>().ToTable("Product");
			modelBuilder.Entity<SallerProductEntity>().ToTable("SallerProduct");
			modelBuilder.Entity<SallerEntity>().ToTable("Saller");
			modelBuilder.Entity<UserRolesEntity>().ToTable("UserRoles");
		}
	}
}
