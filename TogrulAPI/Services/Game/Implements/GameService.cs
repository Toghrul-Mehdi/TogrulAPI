using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.Game;
using TogrulAPI.Services.Game.Abstracts;

namespace TogrulAPI.Services.Game.Implements
{
    public class GameService(TogrulDB _context,IMapper _mapper) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Entities.Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public async Task<IEnumerable<GameGetDto>> Start(Guid id)
        {
            var data = await _context.Games                                
                .FirstOrDefaultAsync(x=>x.Id == id);            
            return (await _context.Games
                .Include(x=>x.Language)
                .Select(x => new GameGetDto
            {
                BannedWordCount = x.BannedWordCount,
                FailCount = x.FailCount,
                SkipCount = x.SkipCount,    
                Time = x.Time,  
                LanguageCode = x.LanguageCode,
                Words = x.Language.Words.Select(x=>x.Text).ToList()
            }).ToListAsync());

        }
    }
}
