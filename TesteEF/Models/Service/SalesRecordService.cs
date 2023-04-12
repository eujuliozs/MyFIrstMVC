using Microsoft.EntityFrameworkCore;
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

    }
}
