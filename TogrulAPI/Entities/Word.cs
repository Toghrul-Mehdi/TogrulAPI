namespace TogrulAPI.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public Language Language { get; set; }
        public IEnumerable<BannedWord> BannedWords { get; set; }
    }
}
