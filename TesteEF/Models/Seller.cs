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
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        public Seller()
        {

        }
        public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Name = name;
            Email = email;
            BirthDate = (birthDate);
            BaseSalary = baseSalary; 
            DepartmentId = department.Id;
        }

        public void AddSales(SalesRecord sale)
        {
            Sales.Add(sale);
        }
        public void RemoveSales(SalesRecord sale)
        {
            Sales.Remove(sale);
        }
        public double TotalSales(DateTime beginning, DateTime end)
        {
            IEnumerable<double> resultado =
                from s in Sales
                where s.Date >= beginning & s.Date <= end
                select s.Amout;

            return resultado.Sum();
        }
        public string Data()
        {
            return BirthDate.ToString(CultureInfo.InvariantCulture);
        }
    }
}
