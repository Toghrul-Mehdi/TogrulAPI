using TogrulAPI.Entities;

namespace TogrulAPI.DTOs.Word
{
    public class WordGetDto
    {
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public List<string> BannedWords { get; set; }
    }
}
