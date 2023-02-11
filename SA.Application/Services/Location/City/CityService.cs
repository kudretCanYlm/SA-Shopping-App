using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Location.City;
using SA.Data.Repository.Media.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Location.City
{
	public class CityService:ICityService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly ICityRepository _cityRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public CityService(ILogger<LoginService> logger, ICityRepository cityRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_cityRepository = cityRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
