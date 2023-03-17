using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteEF.Models;
using TesteEF.Models.Enums;

namespace TesteEF.Data
{
    public class TesteEFContext : DbContext
    {
        public TesteEFContext (DbContextOptions<TesteEFContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
    }
}
