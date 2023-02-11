using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SA.Data.Extensions;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Context
{
	public class SAContext : DbContext, IBaseDbContext
	{
		public SAContext(DbContextOptions options) : base(options)
		{

		}

		//DBSET -> Start
		public DbSet<LoginEntity> Login { get; set; }
		public DbSet<CategoryEntity> Category { get; set; }
		public DbSet<SubCategoryEntity> SubCategory { get; set; }
		public DbSet<ChatEntity> Chat { get; set; }
		public DbSet<MessageEntity> Message { get; set; }
		public DbSet<ImageEntity> Image { get; set; }
		public DbSet<UserEntity> User { get; set; }
		public DbSet<UserDetailEntity> UserDetail { get; set; }
		public DbSet<CommentEntity> Comment { get; set; }
		public DbSet<CommentReplyEntity> CommentReply { get; set; }
		public DbSet<AddressEntity> Address { get; set; }
		public DbSet<CityEntity> City { get; set; }
		public DbSet<CountryEntity> Country { get; set; }
		public DbSet<OrderDetailsEntity> OrderDetails { get; set; }
		public DbSet<OrderEntity> Order { get; set; }
		public DbSet<ProductCategoryEntity> ProductCategory { get; set; }
		public DbSet<ProductEntity> Product { get; set; }
		public DbSet<SallerProductEntity> SallerProduct { get; set; }
		public DbSet<SallerEntity> Saller { get; set; }
		public DbSet<UserRolesEntity> UserRoles { get; set; }
		

		//DBSET -> End

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.OnConfiguringInit();
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.OnModelCreatingInit();
			base.OnModelCreating(modelBuilder);
		}

		public async Task Commit()
		{
			await base.SaveChangesAsync();
		}

		public async Task BeginTransaction()
		{
			await base.Database.BeginTransactionAsync();
		}
		public async Task RollBack()
		{
			await base.Database.BeginTransaction().RollbackAsync();
		}

	}
}
