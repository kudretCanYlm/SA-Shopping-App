using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Web.Mvc.Controllers;
using System.Security.Claims;
using SA.Web.Mvc.Models;
using SA.Application.Services.Auth.Login;
using SA.Application.Contracts.Dtos.Auth.Login;

namespace SA.Web.Mvc.Areas.Admin.Controllers
{
   // [Area("Admin")]
    public class AdminAccountController : Controller
    {
        private readonly ILoginService loginService;

        public AdminAccountController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        
    }
}
