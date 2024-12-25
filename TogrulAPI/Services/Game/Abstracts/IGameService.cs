using TogrulAPI.DTOs.Game;
using TogrulAPI.DTOs.Word;

namespace TogrulAPI.Services.Game.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task<WordForGameDto> Fail (Guid id);
        Task<WordForGameDto> Success(Guid id);
        Task<WordForGameDto> Skip (Guid id);
        Task<GameStatusDto> End(Guid id);
    }
}
