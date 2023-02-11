using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using SA.Application.Contracts.Dtos.Product.SallerProduct;
using SA.Application.Services.Product.Product;
using SA.Application.Services.Product.SallerProduct;
using SA.Application.Services.User.User;
using SA.Domain.Base;
using SA.Web.Mvc.Helpers.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;

namespace SA.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {

        private readonly ISallerProductService _sallerProductService;
        private readonly IProductService _productService;
        private readonly ICreateSallerProductDtoValidator _createSallerProductDtoValidator;
        private readonly IUserService _userService;

		public AdminController(ISallerProductService sallerProductService, IProductService productService, ICreateSallerProductDtoValidator createSallerProductDtoValidator, IUserService userService)
		{
			_sallerProductService = sallerProductService;
			_productService = productService;
			_createSallerProductDtoValidator = createSallerProductDtoValidator;
			_userService = userService;
		}

		[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            
             
            var userId = HttpContext.GetUserId();
            string user = await _userService.GetUserName(userId);
            ViewBag.user = user;

            return View();
        }

        public async Task<IActionResult> Products()
        {

            var userId = HttpContext.GetUserId();
            ViewBag.products =await _sallerProductService.GetSallersProducts(userId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateSallerProductDto createSallerProductDto)
        {
            var result=await _createSallerProductDtoValidator.ValidateAsync(createSallerProductDto);

            if (!result.IsValid)
            {
				result.AddToModelState(this.ModelState); 
                return RedirectToAction("Products",createSallerProductDto);
			}

			createSallerProductDto.SallerId = HttpContext.GetUserId();
			await _sallerProductService.AddSallerProduct(createSallerProductDto);
			return RedirectToAction("Products");
        }

        [HttpGet,AllowAnonymous]
        public async Task<JsonResult> GetProductsSelect()
        {
            var products= await _productService.GetProductsList();
            return Json(products);
		}

	}
}
