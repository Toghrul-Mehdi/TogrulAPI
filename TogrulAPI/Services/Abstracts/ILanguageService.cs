using Microsoft.AspNetCore.Mvc;
using TogrulAPI.DTOs.Language;

namespace TogrulAPI.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task <IEnumerable<LanguageGetDto>> GetAllAsync();
        Task UpdateAsync(string? code, LanguageUpdateDto dto);
        Task DeleteAsync(string? code);
    }
}
