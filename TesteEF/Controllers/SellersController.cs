using Microsoft.AspNetCore.Mvc;
using TesteEF.Models.Service;
using TesteEF.Models.Service.Exceptions;
using TesteEF.Models;
using TesteEF.Models.ViewModel;
using TesteEF.Models.Service.NewFolder;
using Microsoft.AspNetCore.Mvc.TagHelpers;

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
            var ViewModel = new SellerFormViewModel() { Departments=list};
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) 
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _sellerService.FindById(id.Value);
            var department = _departmentService.FindById(seller.DepartmentId);
            var viewmodel = new SellerDetailViewModel(department, seller);
            return View(viewmodel);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            var departmens = _departmentService.FindAll();

            var viewmodel = new SellerFormViewModel() { Departments=departmens, Seller=obj};
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try 
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
            catch(DbConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
    }
}
