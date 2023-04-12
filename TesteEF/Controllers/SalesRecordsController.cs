using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteEF.Data;
using TesteEF.Models;
using TesteEF.Models.Service;

namespace TesteEF.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _saleService;
        private readonly DepartmentsService _departmentsService;
        public SalesRecordsController(SalesRecordService _sales, DepartmentsService departmentsService) 
        { 
            _saleService = _sales;
            _departmentsService = departmentsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SimpleSearch(DateTime? minDate, DateTime? maxDate) 
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd"); ;
            IEnumerable<SalesRecord> query = _saleService.FindByDate(minDate, maxDate);
            return View(query);   
        }
        public IActionResult GropingSearch()
        {
            return View();
        }



    }
}
