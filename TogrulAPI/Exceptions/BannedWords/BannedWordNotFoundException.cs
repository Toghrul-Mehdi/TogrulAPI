namespace TogrulAPI.Exceptions.BannedWords
{
    public class BannedWordNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage {  get; }
        public BannedWordNotFoundException()
        {
            ErrorMessage = "Bele bir data tapilmadi";
        }
        public BannedWordNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
