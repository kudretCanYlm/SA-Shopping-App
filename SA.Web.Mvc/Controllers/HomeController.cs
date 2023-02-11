using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Services.Category.Category;
using SA.Application.Services.Category.SubCategory;
using SA.Application.Services.Product.Product;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Auth.Login;
using SA.Data.Repository.Basket.Basket;
using SA.Domain.Domains.Auth;
using SA.Domain.Domains.Basket;
using SA.Web.Mvc.Models;
using System.Diagnostics;

namespace SA.Web.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISubCategoryService _subCategoryService;
		private readonly IProductService _productService;
		private readonly IBasketRepository _basketRepository;
		private readonly BasketDb _basketDb;

        public HomeController(ILogger<HomeController> logger, ISubCategoryService subCategoryService, IProductService productService, IBasketRepository basketRepository, BasketDb basketDb)
        {
            _logger = logger;
            _subCategoryService = subCategoryService;
            _productService = productService;
            _basketRepository = basketRepository;
            _basketDb = basketDb;
        }

		//[Authorize()]
		[AllowAnonymous]
        public async Task<IActionResult> Index()
		{
			ViewBag.categories=await _subCategoryService.GetSubCategoriesWithImage();
			ViewBag.products = await _productService.GetProductWithImageNoFilter(10);

			BasketDomain basketDomain = new BasketDomain()
			{
				Id=Guid.NewGuid(),
				Ip="192.168.1.1",
				Quantity=5,
				OwnerId=Guid.NewGuid(),
				Price=150,
				ProductId=Guid.NewGuid(),
			};

			var status= _basketRepository.AddToBasket(basketDomain);
			var satus= _basketRepository.AddToBasket(basketDomain);

			var teset = _basketDb.GetAllBaskets();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}