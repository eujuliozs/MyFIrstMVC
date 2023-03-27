using Microsoft.AspNetCore.Mvc;
using TesteEF.Models.Service;
using TesteEF.Models;
using TesteEF.Models.ViewModel;

namespace TesteEF.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentsService _departmentService; 
        public SellersController(SellerService sellerService, DepartmentsService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var list = _departmentService.FindAll();
            var ViewModel = new SellerFormViewModel(list);
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) 
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
