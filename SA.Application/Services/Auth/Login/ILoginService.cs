using SA.Application.Contracts.Dtos.Auth.Login;
using SA.Domain.Domains.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Auth.Login
{
	public interface ILoginService
	{
		public Task<LoginJwtDto> LoginAndGetUser(LoginDto loginDto); 
	}
}
