using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Extensions
{
	public static class DbContextOptionsBuilderExtensions
	{
		public static void OnConfiguringInit(this DbContextOptionsBuilder optionsBuilder)
		{
		  //will add
		}
	}
}
