using TogrulAPI.DTOs.BannedWord;

namespace TogrulAPI.Services.BannedWord.Abstracts
{
    public interface IBannedWordService
    {
        Task CreateAsync(BannedWordCreateDto dto);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task<BannedWordGetDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<bool> UpdateAsync(int id,BannedWordUpdateDto dto);
    }
}
