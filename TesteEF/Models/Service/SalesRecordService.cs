using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using TesteEF.Data;
namespace TesteEF.Models.Service
{
    public class SalesRecordService
    {
        private readonly TesteEFContext _context;
        public SalesRecordService(TesteEFContext context)
        {
            _context = context;
        }
        public List<SalesRecord> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if(minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue) 
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToList();
        }
        public Dictionary<Department, List<SalesRecord>> GroupingSearch(DateTime? minDate, DateTime? maxDate, List<Department> all_departments)
        {
            var result = from Record in _context.SalesRecord select Record;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            result = result.Include(x => x.Seller);
            Dictionary<Department, List<SalesRecord>> search = new();
            foreach(Department department in all_departments)
            {
                List<SalesRecord> SalesOfCurrentDP = result.Where(x => x.Seller.Department.Name == department.Name).ToList();
                search.Add(department, SalesOfCurrentDP);
            }
            return search;
        }

    }
}
