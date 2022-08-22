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

        private static string currentActiveTab = "Category";

        public IActionResult SetCurrentActiveTab (string activeTab)
        {
            currentActiveTab = activeTab;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(ProductCategory category, int brandId)
        {
            
            var brands = await _brandService.GetAllAsync();
            var allProducts = await _productService.GetAllAsync(n => n.Brand);                 
            
            if(category != 0 && brandId != 0)
            {
                var productsByCategory = await _productService.GetProductsByCategory(category);
                var productsByBrand = await _productService.GetProductsByBrandId(brandId);
                if(currentActiveTab == "Category")
                {
                    return View(new ProductIndexViewModel(productsByCategory, allProducts, category, brands, brandId, "Category"));
                }
                if(currentActiveTab == "Brand")
                {
                    return View(new ProductIndexViewModel(allProducts, productsByBrand, 0, brands, brandId, "Brand"));
                }
            };               
            
            if (category != 0 )
            {
                var productsByCategory = await _productService.GetProductsByCategory(category);
                return View(new ProductIndexViewModel(productsByCategory, allProducts, category, brands, brandId, "Category"));               
            }
            if (brandId != 0)
            {
                var productsByBrand = await _productService.GetProductsByBrandId(brandId);
                return View(new ProductIndexViewModel( allProducts,productsByBrand, 0, brands, brandId, "Brand"));
            }
           
            return View(new ProductIndexViewModel(allProducts, allProducts, 0, brands, 0, currentActiveTab));
        }

        public async Task<IActionResult> Create()
        {
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel(new Product(), brands);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                var viewModel = new ProductViewModel(product, brands);
                return View(viewModel);
            }

            await _productService.AddAsync(product);
            return RedirectToAction("Index", new { category = product.Category, brandId = product.BrandId }) ;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel(product, brands);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                var viewModel = new ProductViewModel(product, brands);
                return View(viewModel);
            }
            await _productService.UpdateAsync(product);
            return RedirectToAction("Index", new { category = product.Category, brandId = product.BrandId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index", new { category = product.Category, brandId = product.BrandId });
        }

        public async Task<IActionResult> Show(int id)
        {
            var product = await _productService.GetByIdAsync(id, p => p.Brand);
            return View(product);
        }
    }
}
