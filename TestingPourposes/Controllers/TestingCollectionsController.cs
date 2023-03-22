using Microsoft.AspNetCore.Mvc;
using TestingPourposes.Models;

namespace TestingPourposes.Controllers
{
    public class TestingCollectionsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<TestingCollection> cll = new List<TestingCollection>()
            {
                new TestingCollection(18, "Julio"),
                new TestingCollection(17, "Júllia")
            };
            return View(cll);
        }
    }
}
