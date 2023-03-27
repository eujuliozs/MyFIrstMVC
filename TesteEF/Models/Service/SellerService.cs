﻿using TesteEF.Data;

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
    }
}
