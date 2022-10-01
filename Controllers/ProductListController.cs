using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Enums;
using TuantuanShop.Data.Services;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Controllers
{
    public class ProductListController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly IBannerService _bannerService;

        public ProductListController(IProductService productService, IBrandService brandService, IBannerService bannerService)
        {
            _productService = productService;
            _brandService = brandService;
            _bannerService = bannerService;
        }


        public async Task<IActionResult> New()
        {          
            var banners = await _bannerService.GetBannersByLocation(BannerLocation.New);
            var products = (await _productService.GetNewArrivalProducts()).Select(product => new ProductForListViewModel(product));
            var viewModel = new ProductListViewModel(banners, products);
            return View(viewModel);
        }
    }
}
