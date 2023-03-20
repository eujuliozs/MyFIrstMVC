
namespace TesteEF.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        public void Add(Seller s)
        {
            Sellers.Add(s);
        }
        public Department() 
        { 
        } 
        public Department(string name)
        {
            Name = name;
        }
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateOnly beginning, DateOnly end)
        {
            double resultado = Sellers.Sum(seller => seller.TotalSales(beginning, end));
            return resultado; 
        }
    }

}
