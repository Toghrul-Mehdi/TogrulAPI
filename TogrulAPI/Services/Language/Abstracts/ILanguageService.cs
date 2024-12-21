using TogrulAPI.DTOs.Language;

namespace TogrulAPI.Services.Language.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task<LanguageGetDto> GetByIdAsync(string? code);
        Task<bool> UpdateAsync(string? code, LanguageUpdateDto dto);
        Task DeleteAsync(string? code);
    }
}
