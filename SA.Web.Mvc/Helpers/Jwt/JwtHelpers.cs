using System.Security.Claims;

namespace SA.Web.Mvc.Helpers.Jwt
{
    public static class JwtHelpers
    {
        public static Guid GetUserId(this HttpContext httpContext)
        {
            return Guid.Parse(httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
        }
    }
}
