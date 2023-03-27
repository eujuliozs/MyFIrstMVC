using TesteEF.Data;
namespace TesteEF.Models.Service
{
    public class DepartmentsService
    {
        private readonly TesteEFContext _context;
        public DepartmentsService(TesteEFContext context)
        {
            _context = context;
        }
        public List<Department>FindAll()
        { 
            return _context.Department.OrderBy(dp => dp.Name).ToList();
        }
    }
}
