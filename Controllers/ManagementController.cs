using Microsoft.AspNetCore.Mvc;

namespace TuantuanShop.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
