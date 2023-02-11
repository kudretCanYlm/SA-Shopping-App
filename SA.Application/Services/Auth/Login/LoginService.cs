using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SA.Application.Contracts.Dtos.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Auth.Login;
using SA.Domain.Domains.Auth;
using SA.Domain.Domains.Media;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Auth.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILogger<LoginService> logger;
        private readonly ILoginRepository loginRepository;
        private readonly IUnitOfWork<SAContext> unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;

        public LoginService(ILogger<LoginService> logger, ILoginRepository loginRepository, IUnitOfWork<SAContext> unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            this.logger = logger;
            this.loginRepository = loginRepository;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            _mapper = mapper;
        }

        public async Task<LoginJwtDto> LoginAndGetUser(LoginDto loginDto)
        {
           // var user = await loginRepository.Get(x => x.Password == LoginEntity.ToHashPassword(loginDto.Password) && x.Username == loginDto.Username);
            var user = await loginRepository.Get(x => x.Password == loginDto.Password && x.Username == loginDto.Username);
            

            // return null if user not found
            if (user == null)
                return null;

           var userJwt = _mapper.Map<LoginJwtDto>(user);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userJwt.UserId.ToString()),
                    new Claim(ClaimTypes.Role,userJwt.Role.ToString()),
                    new Claim(ClaimTypes.DateOfBirth,DateTime.Now.Ticks.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(UserStore.Expared),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userJwt.Token = tokenHandler.WriteToken(token);

            // remove password before returning and saved to token repository
            userJwt.Password = null;

            return userJwt;
        }
    }
}
