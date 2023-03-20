using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace TesteEF.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Column(TypeName= "Date")]
        public DateOnly BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public  Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Seller()
        {

        }
        public Seller(string name, string email, DateOnly birthDate, double baseSalary, Department department)
        {
            Name = name;
            Email = email;
            BirthDate = (birthDate);
            BaseSalary = baseSalary; 
            Department = department;
        }

        public void AddSales(SalesRecord sale)
        {
            Sales.Add(sale);
        }
        public void RemoveSales(SalesRecord sale)
        {
            Sales.Remove(sale);
        }
        public double TotalSales(DateOnly beginning, DateOnly end)
        {
            IEnumerable<double> resultado =
                from s in Sales
                where s.Date >= beginning & s.Date <= end
                select s.Amout;

            return resultado.Sum();
        }
    }
}
