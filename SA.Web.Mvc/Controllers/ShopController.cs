using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SA.Application.Contracts.Dtos.Category.Category;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using SA.Application.Contracts.Filters.Product.Product;
using SA.Application.Services.Category.Category;
using SA.Application.Services.Category.SubCategory;
using SA.Application.Services.Product.Product;
using SA.Application.Services.Product.SallerProduct;

namespace SA.Web.Mvc.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly ICreateCategoryDtoValidator _createCategoryDtoValidator;
        private readonly ICreateSubCategoryDtoValidator _createSubCategoryDtoValidator;
        private readonly ISallerProductService _sallerProductService;

        public ShopController(IProductService productService, ISubCategoryService subCategoryService, ICategoryService categoryService, ICreateCategoryDtoValidator createCategoryDtoValidator, ICreateSubCategoryDtoValidator createSubCategoryDtoValidator, ISallerProductService sallerProductService)
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _createCategoryDtoValidator = createCategoryDtoValidator;
            _createSubCategoryDtoValidator = createSubCategoryDtoValidator;
            _sallerProductService = sallerProductService;
        }

        public async Task<IActionResult> Index()
        {
            var products =await  _sallerProductService.GetSallersProductsWithImage();

            return View(products);
        }

        [HttpGet]
        public async Task<JsonResult> GetPricesList()
        {
            var prices = await _productService.GetProductPriceRange();

            return Json(prices);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductListByCategoriesAndPriceRange(GetProductByCategoryAndPriceRange filter)
        {
            var products = await _productService.GetProductWithImageWithFilter(filter);

            return Json(products);
        }

        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            var categories = await _subCategoryService.GetSubCategories();

            return Json(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            bool status;

            if (_createCategoryDtoValidator.Validate(createCategoryDto).IsValid)
            {
                status = await _categoryService.CreateCategory(createCategoryDto);

                if (status)
                    return Json(status);

                return NotFound();
                
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCategory(CreateSubCategoryDto createSubCategoryDto)
        {
            bool status;

            if (_createSubCategoryDtoValidator.Validate(createSubCategoryDto).IsValid)
            {//
                status = await _subCategoryService.CreateSubCategory(createSubCategoryDto);

                if (status)
                    return Json(status);

                return NotFound();

            }

            return NotFound();
        }

        [HttpPost]
        public async Task<JsonResult> AddToBasket()
        {
            throw new Exception();
        }

        [HttpGet]
        public async Task<JsonResult> ProductPriceRange()
        {
            var ranges=await _productService.GetProductPriceRange();
            return Json(ranges);
        }
    }
}
