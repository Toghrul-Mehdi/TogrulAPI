namespace TogrulAPI.DTOs.Language
{
    public class LanguageGetDto
    {
        public string Code { get; set; }
        public string LanguageName { get; set; }
        public string Icon { get; set; }
        public List<string> Words { get; set; }
    }
}
