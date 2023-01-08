using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SA.Data.Extensions;
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

namespace SA.Data.Context
{
	public class SAContext:DbContext,IBaseDbContext
	{
		public SAContext(DbContextOptions options) :base(options)
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

		public void Commit()
		{
			base.SaveChanges();
		}

		public void BeginTransaction()
		{
			base.Database.BeginTransaction();
		}
		public void RollBack()
		{
			base.Database.BeginTransaction().Rollback();
		}

	}
}
