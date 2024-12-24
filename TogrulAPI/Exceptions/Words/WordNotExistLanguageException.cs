namespace TogrulAPI.Exceptions.Words
{
    public class WordNotExistLanguage : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public WordNotExistLanguage()
        {
            ErrorMessage = "Database de bele bir dil movcud deyil,ya dili deyisin yadaki hemin dili elave edin";
        }
        public WordNotExistLanguage(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}