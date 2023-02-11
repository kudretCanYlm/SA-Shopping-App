using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Location.Address;
using SA.Data.Repository.Media.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Location.Address
{
	public class AddressService:IAddressService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IAddressRepository _addressRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public AddressService(ILogger<LoginService> logger, IAddressRepository addressRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_addressRepository = addressRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
