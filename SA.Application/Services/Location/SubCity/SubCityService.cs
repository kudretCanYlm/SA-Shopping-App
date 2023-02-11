using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Location.SubCity;

namespace SA.Application.Services.Location.SubCity
{
	public class SubCityService : ISubCityService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly ISubCityRepository _subCityRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public SubCityService(ILogger<LoginService> logger, ISubCityRepository subCityRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_subCityRepository = subCityRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
