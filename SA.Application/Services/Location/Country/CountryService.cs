using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Location.Country;

namespace SA.Application.Services.Location.Country
{
	public class CountryService : ICountryService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly ICountryRepository _countryRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public CountryService(ILogger<LoginService> logger, ICountryRepository countryRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_countryRepository = countryRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
