using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync(n => n.Brand);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var brands = await _brandService.GetAllAsync();
            var viewModel = new ProductViewModel()
            {
                Brands = brands
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var brands = await _brandService.GetAllAsync();
                request.Brands = brands;
                return View(request);
            }

            await _productService.AddAsync(new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Subtitle = request.Subtitle,
                Category = request.Category,
                OnSale = request.OnSale,
                OnSalePrice = request.OnSalePrice,
                ProfilePictureUrl = request.ProfilePictureUrl,
                IntroductionPictureUrl = request.IntroductionPictureUrl,
                OutOfStock = request.OutOfStock,
                Disabled = request.Disabled,
                BrandId = Int32.Parse(request.BrandId),
            });
            return RedirectToAction("Index");
        }
    }
}
