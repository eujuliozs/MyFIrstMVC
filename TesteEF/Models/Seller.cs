using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace TesteEF.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} is required")]
        [StringLength(60,MinimumLength = 3, ErrorMessage="Minimum Length is 3 and ma length is 60")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [Required(ErrorMessage = "{0} is required")]

        public DateTime BirthDate { get; set; }
        [Display(Name= "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(100, 50000, ErrorMessage ="Salary must between 100 and 50000")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
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
                select s.Amount;

            return resultado.Sum();
        }
        public string Data()
        {
            return BirthDate.ToString(CultureInfo.InvariantCulture);
        }
    }
}
