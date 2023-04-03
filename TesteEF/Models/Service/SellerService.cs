using Microsoft.EntityFrameworkCore;
using TesteEF.Models.Service.Exceptions;
using TesteEF.Data;
using TesteEF.Models.Service.NewFolder;

namespace TesteEF.Models.Service
{
    public class SellerService 
    {
        private readonly TesteEFContext _context;
        public SellerService(TesteEFContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller? FindById(int id) 
        {
            return _context.Seller.Where(seller => seller.Id == id).SingleOrDefault();
        }
        public void Remove(int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if (obj is null)
            {
                throw new NotFoundException("Id not found");
            }
            
            try
            {
                _context.Seller.Update(obj);
                _context.SaveChanges();
            }

            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
