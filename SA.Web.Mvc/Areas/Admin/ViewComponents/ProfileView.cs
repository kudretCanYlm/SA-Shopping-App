using Microsoft.AspNetCore.Mvc;
using SA.Application.Services.User.User;
using SA.Web.Mvc.Helpers.Jwt;

namespace SA.Web.Mvc.Areas.Admin.ViewComponents
{
    public class ProfileView : ViewComponent
    {
        private readonly IUserService _userService;

        public ProfileView(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.GetUserId();
            string user = await _userService.GetUserName(userId);
            ViewBag.user = user;

            return View();
        }
    }
}
