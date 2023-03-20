using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using TesteEF.Models.Enums;

namespace TesteEF.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateOnly Date { get; set; }
        public double Amout { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
        public SalesRecord()
        {

        }
        public SalesRecord(DateOnly date, double amount, SaleStatus status, Seller seller)
        {
            Date = date;
            Amout = amount;
            Status = status;
            Seller = seller;
        }   

    }
}
