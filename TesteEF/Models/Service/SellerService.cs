using Microsoft.EntityFrameworkCore;
using TesteEF.Models.Service.Exceptions;
using TesteEF.Data;
using TesteEF.Models.Service.NewFolder;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public Seller? FindById(int id) 
        {
            return _context.Seller.Where(seller => seller.Id == id).SingleOrDefault();
        }
        public async Task RemoveAsync(int id) 
        {
            var obj = FindById(id);
            try 
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException Ex)
            {
                throw new IntegrityException(Ex.Message);
            }
        }
        public async Task UpdateAsync(Seller obj)
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
