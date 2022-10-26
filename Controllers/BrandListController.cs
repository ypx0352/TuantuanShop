using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Services;

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
    }
}
