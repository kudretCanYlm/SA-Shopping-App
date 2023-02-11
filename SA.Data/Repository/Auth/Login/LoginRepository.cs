using AutoMapper;
using SA.Application.Contracts.Dtos.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Base;
using SA.Domain.Domains.Auth;

namespace SA.Data.Repository.Auth.Login
{

	public class LoginRepository:RepositoryBase<LoginEntity,SAContext>, ILoginRepository
	{
		private readonly IMapper _mapper;

		public LoginRepository(IDatabaseFactory<SAContext> databaseFactory,IMapper mapper):base(databaseFactory)
		{
			_mapper = mapper;
		}

		public async Task<bool> SignInBool(LoginDto loginDto)
		{
			//is there user have same username
			bool isSingle=await Get(x=>x.Username==loginDto.Username&&x.Password==loginDto.Password)==null;

			if (!isSingle)
				return false;

			//add new user login
			await Add(_mapper.Map<LoginEntity>(loginDto));

			return true;
		}
	}


}
