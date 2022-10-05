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

        public async Task<IActionResult> New(SortOrder? sortOrder)
        {
            var banners = await _bannerService.GetBannersByLocation(BannerLocation.New);
            var products = (await _productService.GetNewArrivalProducts()).Select(product => new ProductForListViewModel(product));
            if (sortOrder != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.ProductNameASC:
                        products = products.OrderBy(product => _productService.GetFirstPinyin(product.Name));
                        ViewData["SortOrder"] = "A - Z";
                        break;
                    case SortOrder.ProductNameDESC:
                        products = products.OrderByDescending(product => _productService.GetFirstPinyin(product.Name));
                        ViewData["SortOrder"] = "Z - A";
                        break;
                    case SortOrder.ProductPriceASC:
                        products = products.OrderBy(product => product.Price);
                        ViewData["SortOrder"] = "Price (low to high)";
                        break;
                    case SortOrder.ProductPriceDESC:
                        products = products.OrderByDescending(product => product.Price);
                        ViewData["SortOrder"] = "Price (high to low)";
                        break;
                }
            }
            var viewModel = new ProductListViewModel(banners, products);
            return View(viewModel);
        }

        public async Task<IActionResult> Category(ProductCategory category)
        {
            return View();
        }

       

        

    }
};
