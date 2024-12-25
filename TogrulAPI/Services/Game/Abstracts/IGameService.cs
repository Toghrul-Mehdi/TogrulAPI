using TogrulAPI.DTOs.Game;
using TogrulAPI.DTOs.Word;

namespace TogrulAPI.Services.Game.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task Fail (Guid id);
        Task Success(Guid id);
        Task Skip (Guid id);
        Task End(Guid id);
    }
}
