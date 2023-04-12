namespace TesteEF.Models.Service.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string Message) : base(Message)
        { 
        }
    }
}
