namespace TogrulAPI.Exceptions.BannedWords
{
    public class BannedWordExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage {  get; }

        public BannedWordExistException()
        {
            ErrorMessage = "Banlanmish soz movcuddur";
        }
        public BannedWordExistException(string messsage) : base(messsage)
        {
            ErrorMessage = messsage;
        }
    }
}
