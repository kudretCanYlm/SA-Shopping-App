using SA.Domain.Base;

namespace SA.Application.Contracts.Dtos.Auth.Login
{
    public class LoginJwtDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public RoleEnum Role { get; set; }
        public Guid UserId { get; set; }
    }
}
