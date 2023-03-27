namespace TesteEF.Models.ViewModel
{
    public class SellerDetailViewModel
    {
        public Department Department { get; set; }
        public Seller Seller  { get; set; }
        public SellerDetailViewModel(Department dp, Seller sl) 
        {
            Department = dp;
            Seller = sl;
        }
    }
}
