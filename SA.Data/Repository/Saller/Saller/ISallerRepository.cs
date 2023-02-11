using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Saller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Saller.Saller
{
	public interface ISallerRepository:IRepository<SallerEntity>
	{
	}

	public class SallerRepository:RepositoryBase<SallerEntity,SAContext>,ISallerRepository
	{
		public SallerRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
