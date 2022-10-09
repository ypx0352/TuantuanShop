using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Enums;
using TuantuanShop.Data.Services;
using TuantuanShop.ViewModels;
using Newtonsoft.Json;

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


        public async Task<IActionResult> New(SortOrder? sortOrder, string? filter)
        {
            var banners = await _bannerService.GetBannersByLocation(BannerLocation.New);
            var products = (await _productService.GetNewArrivalProducts()).Select(product => new ProductForListViewModel(product));
            var brands = _productService.GetUniqueBrands(products);

            if (!string.IsNullOrEmpty(filter))
            {
                ProductListFilter filterObj = JsonConvert.DeserializeObject<ProductListFilter>(filter);
                if (filterObj.tags != null)
                {
                    if (filterObj.tags.Count() > 0)
                    {
                        products = _productService.FilterProductsByTag(products, filterObj.tags);
                        ViewData["FilterObj"] = filterObj;
                    }
                }

                if (filterObj.brands != null)
                {
                    if (filterObj.brands.Count() > 0)
                    {
                        products = _productService.FilterProductsByBrand(products, filterObj.brands);
                        ViewData["FilterObj"] = filterObj;
                    }
                }
            }

            if (sortOrder != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.ProductNameASC:
                        products = products.OrderBy(product => _productService.GetFirstPinyin(product.Name));
                        ViewData["SortOrderText"] = "A - Z";
                        ViewData["SortOrderCode"] = SortOrder.ProductNameASC;
                        break;
                    case SortOrder.ProductNameDESC:
                        products = products.OrderByDescending(product => _productService.GetFirstPinyin(product.Name));
                        ViewData["SortOrderText"] = "Z - A";
                        ViewData["SortOrderCode"] = SortOrder.ProductNameDESC;
                        break;
                    case SortOrder.ProductPriceASC:
                        products = products.OrderBy(product => product.OnSale ? product.OnSalePrice : product.Price);
                        ViewData["SortOrderText"] = "Price (low)";
                        ViewData["SortOrderCode"] = SortOrder.ProductPriceASC;
                        break;
                    case SortOrder.ProductPriceDESC:
                        products = products.OrderByDescending(product => product.OnSale ? product.OnSalePrice : product.Price);
                        ViewData["SortOrderText"] = "Price (high)";
                        ViewData["SortOrderCode"] = SortOrder.ProductPriceDESC;
                        break;
                }
            }

            var viewModel = new ProductListViewModel(banners, products,brands);
            return View(viewModel);
        }   


        public async Task<IActionResult> Category(ProductCategory category)
        {
            return View();
        }

    }    
};
