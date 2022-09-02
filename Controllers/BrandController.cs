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

        // Brand list for management
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

        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            await _service.UpdateAsync(brand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        //Brand list for users
        public async Task<IActionResult> List()
        {
            var brands = await _service.GetAllAsync();
            return View(brands);
        }

        public async Task<IActionResult> Show(int id)
        {
            var brand = await _service.GetByIdAsync(id, b => b.Products);
            return View(brand);
        }
    }
}
