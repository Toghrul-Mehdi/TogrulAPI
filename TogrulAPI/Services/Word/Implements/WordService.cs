using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.Language;
using TogrulAPI.DTOs.Word;
using TogrulAPI.Entities;
using TogrulAPI.Exceptions.Languages;
using TogrulAPI.Exceptions.Words;
using TogrulAPI.Services.Word.Abstracts;

namespace TogrulAPI.Services.Word.Implements
{
    public class WordService(TogrulDB _context,IMapper _mapper) : IWordService
    {
        public async Task CreateAsync(WordCreateDto dto)
        {
            if(await _context.Words.AnyAsync(x=>x.Text == dto.Text))
            {
                throw new WordExistException();
            }
            if (!await _context.Languages.AnyAsync(x =>x.Code == dto.LanguageCode))
            {
                throw new WordNotExistLanguage();
            }
            await _context.AddAsync(new Entities.Word
            {
                Text = dto.Text,
                LanguageCode = dto.LanguageCode,
                BannedWords =dto.BannedWords.Select(x=> new Entities.BannedWord
                {
                    Text=x
                }).ToList()
                
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Words.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Words.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            return await _context.Words
               .Include(x => x.BannedWords)
               .Select(x => new WordGetDto
               {
                   LanguageCode = x.LanguageCode,
                   Text = x.Text,
                   BannedWords = x.BannedWords.Select(x => x.Text).ToList()
               }).ToListAsync();
        }

        public async Task<WordGetDto> GetByIdAsync(int id)
        {
            var data = await _context.Words
                .Include (x => x.BannedWords)
                .FirstOrDefaultAsync(x=>x.Id == id);
            if (data == null)
                throw new WordNotFoundException();

            var dto = new WordGetDto
            {
                Text = data.Text,
                LanguageCode = data.LanguageCode,
                BannedWords = data.BannedWords.Select(x=>x.Text).ToList()
            };
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, WordUpdateDto dto)
        {
            var data = _context.Words.FirstOrDefault(x=>x.Id==id);
            if (data == null)
            {
                return false;
            }


            data.Text = dto.Text;
            data.LanguageCode = dto.LanguageCode;


            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
