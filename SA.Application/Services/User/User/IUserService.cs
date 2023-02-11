using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.User.User
{
	public interface IUserService
	{
		public Task<string> GetUserName(Guid UserId);
	}
}
