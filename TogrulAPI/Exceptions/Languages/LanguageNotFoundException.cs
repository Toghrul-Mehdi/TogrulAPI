namespace TogrulAPI.Exceptions.Languages
{
    public class LanguageNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage {  get; }
        public LanguageNotFoundException()
        {
            ErrorMessage = "Bele bir data tapilmadi";
        }
        public LanguageNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
