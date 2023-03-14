using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteEF.Models.Departments;

namespace TesteEF.Data
{
    public class TesteEFContext : DbContext
    {
        public TesteEFContext (DbContextOptions<TesteEFContext> options)
            : base(options)
        {
        }

        public DbSet<TesteEF.Models.Departments.Departments> Departments { get; set; } = default!;
    }
}
