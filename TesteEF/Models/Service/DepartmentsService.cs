using TesteEF.Data;
using Microsoft.EntityFrameworkCore;
namespace TesteEF.Models.Service
{
    public class DepartmentsService
    {
        private readonly TesteEFContext _context;
        public DepartmentsService(TesteEFContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        { 
            return _context.Department.OrderBy(dp => dp.Name).ToList();
        }
        public async Task<Department> FindByIdAsync(int id)
        {
            return await _context.Department.Where(dp => dp.Id == id).SingleOrDefaultAsync();
        }
    }
}
