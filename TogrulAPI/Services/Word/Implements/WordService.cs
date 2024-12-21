using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.Language;
using TogrulAPI.DTOs.Word;
using TogrulAPI.Services.Word.Abstracts;

namespace TogrulAPI.Services.Word.Implements
{
    public class WordService(TogrulDB _context) : IWordService
    {
        public async Task CreateAsync(WordCreateDto dto)
        {
            await _context.AddAsync(new Entities.Word
            {
                Text = dto.Text,
                LanguageCode = dto.LanguageCode,
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
            return await _context.Words.Select(x => new WordGetDto
            {
                LanguageCode = x.LanguageCode,
                Text = x.Text,
            }).ToListAsync();
        }

        public async Task<WordGetDto> GetByIdAsync(int id)
        {
            var data = await _context.Words.FirstOrDefaultAsync(x=>x.Id == id);    
            if (data == null)
            {
                return null;
            }
            var dto = new WordGetDto
            {
                Text = data.Text,
                LanguageCode = data.LanguageCode,
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
