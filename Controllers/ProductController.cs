using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Enums;
using TuantuanShop.Data.Services;
using TuantuanShop.Models;
using TuantuanShop.ViewModels;

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

        //private static string currentActiveTab = "Category";

        //public IActionResult SetCurrentActiveTab(string activeTab)
        //{
        //    currentActiveTab = activeTab;
        //    return RedirectToAction("Index");
        //}

        public IActionResult Index()
        {
            return RedirectToAction("IndexCategoryTab");
        }

        public async Task<IActionResult> IndexCategoryTab(ProductCategory category, bool returnAll)
        {
            IEnumerable<Product> products;
            if (category == 0 || returnAll)
            {
                products = await _productService.GetAllAsync(p => p.Brand);
                ViewData["ReturnAll"] = true;                
                category = 0;
            }
            else
            {
                products = await _productService.GetProductsByCategory(category);
                ViewData["ReturnAll"] = false;
            }

            return View("IndexCategoryTab", new ProductIndexCategoryTabViewModel(products, category));
        }

        public async Task<IActionResult> IndexBrandTab(int brandId, bool returnAll)
        {
            IEnumerable<Product> products;
            var brands = await _brandService.GetAllAsync();
            if (brandId == 0 || returnAll)
            {
                products = await _productService.GetAllAsync(p => p.Brand);
                ViewData["ReturnAll"] = true;
                brandId = 0;
            }
            else
            {
                products = await _productService.GetProductsByBrandId(brandId);
                ViewData["ReturnAll"] = false;
            }
            return View("IndexBrandTab", new ProductIndexBrandTabViewModel(products, brands, brandId));

        }

        public async Task<IActionResult> Create(string? returnAction, ProductCategory category, int brandId)
        {
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel(new Product(), brands);
            ViewData["ReturnAction"] = returnAction;            
            ViewData["BrandId"] = brandId;
            if(category != 0)
            {
                ViewData["Category"] = category;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, string returnAction = "Index")
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                var viewModel = new ProductViewModel(product, brands);
                return View(viewModel);
            }
            await _productService.AddAsync(product);
            return RedirectToAction(returnAction, new { category = product.Category, brandId = product.BrandId });
        }

        public async Task<IActionResult> Edit(int id, string returnAction, bool returnAll)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel(product, brands);
            ViewData["ReturnAction"] = returnAction;
            ViewData["ReturnAll"] = returnAll;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, string returnAction, bool returnAll)
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                var viewModel = new ProductViewModel(product, brands);
                ViewData["ReturnAction"] = returnAction;
                ViewData["ReturnAll"] = returnAll;
                return View(viewModel);
            }
            await _productService.UpdateAsync(product);
            var category = product.Category;
            var brandId = product.BrandId;
            if (returnAll)
            {
                category = 0;
                brandId = 0;
            }
            return RedirectToAction(returnAction, new { category = category, brandId = brandId });
        }

        public async Task<IActionResult> Details(int id, string returnAction, bool returnAll)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            ViewData["ReturnAction"] = returnAction;
            ViewData["ReturnAll"] = returnAll;
            return View(product);
        }

        public async Task<IActionResult> Delete(int id, string returnAction, bool returnAll)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            ViewData["ReturnAction"] = returnAction;
            ViewData["ReturnAll"] = returnAll;
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, string returnAction, bool returnAll)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(id);
            var category = product.Category;
            var brandId = product.BrandId;
            if (returnAll)
            {
                category = 0;
                brandId = 0;
            }
            return RedirectToAction(returnAction, new { category = category, brandId = brandId });
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

        public async Task<IActionResult> List()
        {
            var products = (await _productService.GetAllAsync()).Select(product => new ProductForListViewModel(product));
            var brandNames = (await _brandService.GetAllAsync()).Select(brand => brand.Name);
            ViewData["BrandNames"] = brandNames;
            return View(products);
        }
    }
}
