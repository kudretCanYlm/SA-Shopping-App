using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Media.Image;
using SA.Data.Repository.User.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.User.UserDetail
{
	public class UserDetailService:IUserDetailService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IUserDetailRepository _userDetailRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public UserDetailService(ILogger<LoginService> logger, IUserDetailRepository userDetailRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_userDetailRepository = userDetailRepository;
			_unitOfWork = unitOfWork;
		}
	}
}
