namespace TogrulAPI.DTOs.Word
{
    public class WordForGameDto
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public List<string> BannedWord { get; set; }
    }
}
