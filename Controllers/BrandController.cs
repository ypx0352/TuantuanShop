using Microsoft.AspNetCore.Mvc;
using TuantuanShop.Data.Services;
using TuantuanShop.Models;

namespace TuantuanShop.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            await _service.AddAsync(brand);
            return RedirectToAction("Index");
        }

    }
}
