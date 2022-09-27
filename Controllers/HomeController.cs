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
        private readonly IBannerService _bannerService;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IProductService productService, IBrandService brandService, IBannerService bannerService)
        {
            _productService = productService;
            _brandService = brandService;
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _bannerService.GetBannersByLocation(BannerLocation.Home);
            var hotSaleProducts = (await _productService.GetEnabledHotSaleProducts()).Select(product => new ProductForListViewModel(product)).ToList();
            var newArrivalProducts = (await _productService.GetNewArrivalProducts()).Select(product => new ProductForListViewModel(product)).ToList();
            var inStockProducts = (await _productService.GetEnabledInStockProducts()).Select(product => new ProductForListViewModel(product)).ToList();
           
            var viewModel = new HomeIndexViewModel(banners,hotSaleProducts, newArrivalProducts, inStockProducts);
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