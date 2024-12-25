namespace TogrulAPI.DTOs.Game
{
    public class GameGetDto
    {
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public string LanguageCode { get; set; }
        public List<string> Words { get; set; }
    }
}
