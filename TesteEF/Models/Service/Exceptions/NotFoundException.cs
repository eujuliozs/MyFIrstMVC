namespace TesteEF.Models.Service.NewFolder
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) :base(message) 
        {
            
        }
    }
}
