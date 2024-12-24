namespace TogrulAPI.Exceptions.BannedWords
{
    public class BannedWordNotExistWord : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public BannedWordNotExistWord()
        {
            ErrorMessage = "Database de bele bir Id li soz tapilmadi zehmet olmasa id ni deyisin ve ya hemin id li soz daxil edin";
        }
        public BannedWordNotExistWord(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}

