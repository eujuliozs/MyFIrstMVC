using Microsoft.AspNetCore.Mvc;

namespace TesteEF.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
