using Microsoft.EntityFrameworkCore;
using SA.Domain.Domains.Auth;
using SA.Domain.Domains.Category;
using SA.Domain.Domains.Chat;
using SA.Domain.Domains.Media;
using SA.Domain.Domains.User;
using System;
using System.Collections.Generic;
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
		}
	}
}
