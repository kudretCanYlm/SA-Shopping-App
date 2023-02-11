using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Base.Interfaces;
using SA.Domain.Domains.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Data.Repository.Location.City
{
	public class CityRepository:RepositoryBase<CityEntity,SAContext>,ICityRepository
	{
		public CityRepository(IDatabaseFactory<SAContext> databaseFactory):base(databaseFactory)
		{

		}
	}
}
