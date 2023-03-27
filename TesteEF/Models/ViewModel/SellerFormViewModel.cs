namespace TesteEF.Models.ViewModel
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public SellerFormViewModel(List<Department> list)
        {
            Departments = list; 
        }
    }
}
