using SA.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Infrastructure
{
	public interface IDatabaseFactory<DbContext>:IDisposable where DbContext:Microsoft.EntityFrameworkCore.DbContext, IBaseDbContext

	{
		DbContext Get();
	}
}
