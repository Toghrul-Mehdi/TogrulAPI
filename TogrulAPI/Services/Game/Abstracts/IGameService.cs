using TogrulAPI.DTOs.Game;

namespace TogrulAPI.Services.Game.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<IEnumerable<GameGetDto>> Start(Guid id);
    }
}
