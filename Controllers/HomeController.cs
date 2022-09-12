using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TuantuanShop.Data.Enums;
using TuantuanShop.Data.Services;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var hotSaleProducts = (await _productService.GetEnabledHotSaleProducts()).Select(product => new ProductForListViewModel(product)).ToList();
            var newArrivalProducts = (await _productService.GetNewArrivalProducts()).Select(product => new ProductForListViewModel(product)).ToList();
            var formulaProducts = (await _productService.GetEnabledProductsByCategory(ProductCategory.Formula)).Take(6).Select(product => new ProductForListViewModel(product)).ToList();
            var babyCareProducts = (await _productService.GetEnabledProductsByCategory(ProductCategory.BabyCare)).Take(6).Select(product => new ProductForListViewModel(product)).ToList();
            var vitaminsProducts = (await _productService.GetEnabledProductsByCategory(ProductCategory.Vitamins)).Take(6).Select(product => new ProductForListViewModel(product)).ToList();
            var homeProducts = (await _productService.GetEnabledProductsByCategory(ProductCategory.Home)).Take(6).Select(product => new ProductForListViewModel(product)).ToList();
            var personalCareProducts = (await _productService.GetEnabledProductsByCategory(ProductCategory.PersonalCare)).Take(6).Select(product => new ProductForListViewModel(product)).ToList();
            var beautyProducts = (await _productService.GetEnabledProductsByCategory(ProductCategory.Beauty)).Take(6).Select(product => new ProductForListViewModel(product)).ToList();
            var viewModel = new HomeIndexViewModel(hotSaleProducts, newArrivalProducts, formulaProducts, babyCareProducts, vitaminsProducts, homeProducts, personalCareProducts,beautyProducts);
            return View(viewModel);
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