using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.BannedWord;
using TogrulAPI.DTOs.Language;
using TogrulAPI.Exceptions.BannedWords;
using TogrulAPI.Services.BannedWord.Abstracts;

namespace TogrulAPI.Services.BannedWord.Implements
{
    public class BannedWordService(TogrulDB _context) : IBannedWordService
    {
        public async Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            return await _context.BannedWords
                .Include(x=>x.Word)
                .Select(x => new BannedWordGetDto
            {
                Text = x.Text,
                WordId = x.WordId,
                Word = x.Word.Text
            }).ToListAsync();
        }

        public async Task CreateAsync(BannedWordCreateDto dto)
        {
            if(await _context.BannedWords.AnyAsync(x => x.Text == dto.Text))
            {
                throw new BannedWordExistException();
            }
            if (!await _context.BannedWords.AnyAsync(x => x.WordId == dto.WordId))
            {
                throw new BannedWordNotExistWord();
            }
            await _context.AddAsync(new Entities.BannedWord
            {
                Text = dto.Text,
                WordId = dto.WordId,
            });
            await _context.SaveChangesAsync();
        }
        public async Task<BannedWordGetDto> GetByIdAsync(int id)
        {
            var data = await _context.BannedWords
                .Include (x=>x.Word)
                .FirstOrDefaultAsync(x => x.Id==id);
            if (data == null)
            {
                throw new BannedWordNotFoundException();
            }
            var dto = new BannedWordGetDto
            {
                   Text= data.Text,
                   WordId = data.WordId,
                   Word = data.Word.Text
            };
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, BannedWordUpdateDto dto)
        {
            var data = await _context.BannedWords.FirstOrDefaultAsync(x => x.Id==id);

            if (data == null)
            {
                return false;
            }


            data.Text = dto.Text;
            data.WordId = dto.WordId;


            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.BannedWords.FirstOrDefaultAsync(x => x.Id==id);
            if (data != null)
            {
                _context.BannedWords.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
