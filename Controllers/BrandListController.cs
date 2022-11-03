using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Services;
using TuantuanShop.ViewModels;

namespace TuantuanShop.Controllers
{
    public class BrandListController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly IBannerService _bannerService;

        public BrandListController(IProductService productService, IBrandService brandService, IBannerService bannerService)
        {
            _productService = productService;
            _brandService = brandService;
            _bannerService = bannerService;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = await _brandService.GetBrandNameGroups();
            return View(viewModel);
        }

        public async Task<IActionResult> Show(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            var allProducts = (await _productService.GetEnabledProductsByBrandId(id));
            var products = allProducts.Select(product => new ProductForListViewModel(product));
            var bestsellers = allProducts.OrderByDescending(product => product.SoldCount).Take(8).Select(product => new ProductForListViewModel(product));
            return View(new BrandListShowViewModel { Brand = brand, Products = products, Bestsellers = bestsellers });
        }
    }
}
