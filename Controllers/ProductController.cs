using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Enums;
using TuantuanShop.Data.Services;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;
using Newtonsoft.Json;


namespace TuantuanShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        public ProductController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index(string filters, string tab = "category", ProductCategory category = 0, int brandId = 0)
        {
            if (filters == null)
            {
                filters = JsonConvert.SerializeObject(new { OnSale = false, InStock = false, HotSale = false });
            }

            IEnumerable<ProductForListViewModel> products;

            if (tab == "category" && category != 0)
            {
                products = (await _productService.GetProductsByCategory(category)).Select(product => new ProductForListViewModel(product));
            }
            else if (tab == "brand" && brandId != 0)
            {
                products = (await _productService.GetProductsByBrandId(brandId)).Select(product => new ProductForListViewModel(product));
            }
            else
            {
                products = (await _productService.GetAllAsync()).Select(product => new ProductForListViewModel(product));
            }

            dynamic filtersObj = JsonConvert.DeserializeObject(filters);
            if (filters.Contains("true"))
            {
                products = _productService.FilterProducts(products, filters);
            }
            var brands = (await _brandService.GetAllAsync()).Select(brand => new ProductBrandForSidebarModelView(brand));

            ViewData["Tab"] = tab;
            ViewData["Category"] = category;
            ViewData["Caller"] = "Management";
            ViewData["Brands"] = brands;
            ViewData["BrandId"] = brandId;
            ViewData["Filters"] = filters;

            return View(products);
        }

        public async Task<IActionResult> IndexCategoryTab(ProductCategory category, bool returnAll, string filters = "")
        {
            IEnumerable<ProductForListViewModel> products;

            if (filters == null)
            {
                filters = "";
            }

            if (category == 0 || returnAll)
            {
                products = (await _productService.GetAllAsync()).Select(product => new ProductForListViewModel(product));
                ViewData["ReturnAll"] = true;
                category = 0;
            }
            else
            {
                products = (await _productService.GetProductsByCategory(category)).Select(product => new ProductForListViewModel(product));
                ViewData["ReturnAll"] = false;
            }
            ViewData["Filters"] = filters;

            if (filters.Trim().Length > 0)
            {
                products = _productService.FilterProducts(products, filters);
            }

            return View("IndexCategoryTab", new ProductIndexCategoryTabViewModel(products, category));
        }

        public async Task<IActionResult> IndexBrandTab(int brandId, bool returnAll, string filters)
        {
            IEnumerable<ProductForListViewModel> products;

            if (filters == null)
            {
                filters = "";
            }

            var brands = (await _brandService.GetAllAsync()).Select(brand => new ProductBrandForSidebarModelView(brand));
            if (brandId == 0 || returnAll)
            {
                products = (await _productService.GetAllAsync()).Select(product => new ProductForListViewModel(product));
                ViewData["ReturnAll"] = true;
                brandId = 0;
            }
            else
            {
                products = (await _productService.GetProductsByBrandId(brandId)).Select(product => new ProductForListViewModel(product));
                ViewData["ReturnAll"] = false;
            }
            ViewData["Filters"] = filters;

            if (filters.Trim().Length > 0)
            {
                products = _productService.FilterProducts(products, filters);
            }

            return View("IndexBrandTab", new ProductIndexBrandTabViewModel(products, brands, brandId));
        }

        public async Task<IActionResult> Create(ProductCategory category = 0, int brandId = 0, string tab = "category", string callerController = "Product")
        {
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel(new Product(), brands);
            ViewData["Category"] = category;
            ViewData["BrandId"] = brandId;
            ViewData["Tab"] = tab;
            ViewData["CallerController"] = callerController;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, string tab = "category")
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                var viewModel = new ProductViewModel(product, brands);
                return View(viewModel);
            }
            await _productService.AddAsync(product);
            return RedirectToAction("Index", new { category = product.Category, brandId = product.BrandId, tab = tab });
        }

        public async Task<IActionResult> Edit(int id, string tab = "category")
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel(product, brands);
            ViewData["Tab"] = tab;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, string tab = "category")
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                var viewModel = new ProductViewModel(product, brands);
                ViewData["Tab"] = tab;
                return View(viewModel);
            }
            await _productService.UpdateAsync(product);
            var category = product.Category;
            var brandId = product.BrandId;
            return RedirectToAction("Index", new { category = category, brandId = brandId, tab = tab });
        }

        public async Task<IActionResult> Details(int id, string tab = "category")
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            ViewData["Tab"] = tab;
            return View(product);
        }

        public async Task<IActionResult> Delete(int id, string tab = "category")
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            ViewData["Tab"] = tab;
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, string tab = "category")
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(id);
            var category = product.Category;
            var brandId = product.BrandId;
            return RedirectToAction("Index", new { category = category, brandId = brandId, tab = tab });
        }

        // For user's view
        public async Task<IActionResult> Show(int id)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            var viewModel = new ProductShowViewModel()
            {
                Product = product,
                HotSaleProducts = (await _productService.GetHotSaleProducts()).Select(product => new ProductForListViewModel(product))
            };
            return View(viewModel);
        }

        public async Task<IActionResult> HotSaleList()
        {
            var hotSaleProducts = (await _productService.GetHotSaleProducts()).Select(product => new ProductForListViewModel(product));
            return View(hotSaleProducts);
        }

        public async Task<IActionResult> InStockList()
        {
            var inStockProducts = (await _productService.GetInStockProducts()).Select(product => new ProductForListViewModel(product));
            return View(inStockProducts);
        }

        public async Task<IActionResult> List(string filters, string tab = "category", ProductCategory category = 0, int brandId = 0)
        {
            if (filters == null)
            {
                filters = JsonConvert.SerializeObject(new { OnSale = false, InStock = false, HotSale = false });
            }

            IEnumerable<ProductForListViewModel> products;

            if (tab == "category" && category != 0)
            {
                products = (await _productService.GetProductsByCategory(category)).Select(product => new ProductForListViewModel(product));
            }
            else if (tab == "brand" && brandId != 0)
            {
                products = (await _productService.GetProductsByBrandId(brandId)).Select(product => new ProductForListViewModel(product));
            }
            else
            {
                products = (await _productService.GetAllAsync()).Select(product => new ProductForListViewModel(product));
            }

            dynamic filtersObj = JsonConvert.DeserializeObject(filters);
            if (filters.Contains("true"))
            {
                products = _productService.FilterProducts(products, filters);
            }
            var brands = (await _brandService.GetAllAsync()).Select(brand => new ProductBrandForSidebarModelView(brand));

            ViewData["Tab"] = tab;
            ViewData["Category"] = category;
            ViewData["Caller"] = "User";
            ViewData["Brands"] = brands;
            ViewData["BrandId"] = brandId;
            ViewData["Filters"] = filters;

            return View(products);
        }
    }
}
