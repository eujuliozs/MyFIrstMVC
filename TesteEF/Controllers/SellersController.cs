using Microsoft.AspNetCore.Mvc;
using TesteEF.Models.Service;
using TesteEF.Models.Service.Exceptions;
using TesteEF.Models;
using TesteEF.Models.ViewModel;
using TesteEF.Models.Service.NewFolder;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
        public async Task<IActionResult> Create()
        {

            var list =  _departmentService.FindAll();
            var ViewModel = new SellerFormViewModel() { Departments=list};
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) 
        {
            if(!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id was not provided"});
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            { 
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException Ie)
            {
                return RedirectToAction(nameof(Error), new {Message=Ie.Message});
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Found" }); ;
            }

            var seller = _sellerService.FindById(id.Value);
            var department = await _departmentService.FindByIdAsync(seller.Id);
            var viewmodel = new SellerDetailViewModel(department, seller);
            return View(viewmodel);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id was not provided" });
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Found" });
            }
            var departmens = _departmentService.FindAll();

            var viewmodel = new SellerFormViewModel() { Departments = departmens , Seller=obj};
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Departments=departments, Seller=seller};
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new
                {
                    message = "Id missmatch"
                });
            }
            try 
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex) 
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    
            };
            return View(viewModel);

        }
    }
}
