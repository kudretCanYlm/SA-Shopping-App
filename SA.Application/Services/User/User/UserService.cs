using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Media.Image;
using SA.Data.Repository.User.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.User.User
{
	public class UserService:IUserService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public UserService(ILogger<LoginService> logger, IUserRepository userRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<string> GetUserName(Guid UserId)
		{
			var user = await _userRepository.GetById(UserId);
			return user.FirstName + " " + user.LastName;
		}
	}
}
