using Microsoft.AspNetCore.Mvc;
using TogrulAPI.DTOs.Language;

namespace TogrulAPI.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task <IEnumerable<LanguageGetDto>> GetAllAsync();
        Task UpdateAsync(int? id, LanguageUpdateDto dto);
        Task DeleteAsync(int? id);
    }
}
