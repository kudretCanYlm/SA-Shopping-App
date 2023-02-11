using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Contracts.Dtos.Auth.Login;
using SA.Application.Services.Auth.Login;
using SA.Web.Mvc.Controllers;
using System.Security.Claims;
using FluentValidation.AspNetCore;

namespace SA.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        private readonly ILoginDtoValidator loginDtoValidator;

		public LoginController(ILoginService loginService, ILoginDtoValidator loginDtoValidator)
		{
			this.loginService = loginService;
			this.loginDtoValidator = loginDtoValidator;
		}

		[AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto model, string returnUrl = null)
        {
            var result=loginDtoValidator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Login");
            }

			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = await loginService.LoginAndGetUser(model);

				if (user == null)
				{
					ModelState.AddModelError("", "username or password is invalid");
					return View(model);
				}

				var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
				identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Token));
				identity.AddClaim(new Claim(ClaimTypes.Name, user.UserId.ToString()));
				identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));

				//identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));

				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberMe });

				return RedirectToLocal("login/login");
			}

			return View(model);
		}
        public async Task<IActionResult> Logout()
        {
            var token = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Login");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}
