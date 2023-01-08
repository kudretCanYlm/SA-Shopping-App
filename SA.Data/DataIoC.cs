using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Auth.Login;
using SA.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data
{
	public static class DataIoC
	{
		public static void SetDataIoC(this IServiceCollection services)
		{

			services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
			services.AddScoped(typeof(IDatabaseFactory<>), typeof(DatabaseFactory<>));
			


			services.AddScoped<ILoginRepository, LoginRepository>();

			
			//var interfaces=Assembly.GetExecutingAssembly().GetTypes().Where(x=>x.GetInterfaces().Where(x=>x.Name.("I")))

		}
	}
}
