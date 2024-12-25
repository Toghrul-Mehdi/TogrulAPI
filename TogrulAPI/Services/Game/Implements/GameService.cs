using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.Game;
using TogrulAPI.DTOs.Word;
using TogrulAPI.Extensions;
using TogrulAPI.Services.Game.Abstracts;

namespace TogrulAPI.Services.Game.Implements
{
    public class GameService(TogrulDB _context,IMapper _mapper,IMemoryCache _cache) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Entities.Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public Task End(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Fail(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status =  _getCurrentGame(id);
            if(status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++;
                _cache.Set(id , status,TimeSpan.FromSeconds(300));
                return currentWord;
            }
            return null;
        }

        public async Task<WordForGameDto> Start(Guid id)
        {
           var game = await _context.Games.FindAsync(id);
           if (game is null) throw new Exception();
           IQueryable<Entities.Word> query = _context.Words
                 .Where(x => x.LanguageCode == game.LanguageCode);
           var words = await query                
                .Select(x=> new WordForGameDto
                {
                    Id = x.Id,
                    Word =x.Text,
                    BannedWord = x.BannedWords.Select(y=>y.Text).ToList()
                })                
                .ToListAsync();
            var randomWords = words.OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            var wordsStack = new Stack<WordForGameDto>(randomWords);
            WordForGameDto currentWord = wordsStack.Pop();
            GameStatusDto status = new GameStatusDto
            {
                Fail = 0,
                Skip = 0,
                Success = 0,
                MaxSkipCount = game.SkipCount,
                Words = wordsStack,
                UsedWordIds = words.Select(x=>x.Id)
            };
            _cache.Set(id, status,TimeSpan.FromSeconds(300));
            return currentWord;
        }

        public Task Success(Guid id)
        {
            throw new NotImplementedException();
        }
        GameStatusDto _getCurrentGame(Guid id)
        {
            var result  = _cache.Get<GameStatusDto>(id);
            if (result == null) throw new Exception();
            return result;  
        }
    }
}
