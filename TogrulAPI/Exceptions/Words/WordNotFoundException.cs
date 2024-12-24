namespace TogrulAPI.Exceptions.Words
{
    public class WordNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage {  get;  }
        public WordNotFoundException()
        {
            ErrorMessage = "Bele bir data tapilmadi";
        }
        public WordNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
