using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.Language;
using TogrulAPI.Entities;
using TogrulAPI.Exceptions.Languages;
using TogrulAPI.Services.Language.Abstracts;

namespace TogrulAPI.Services.Language.Implements
{
    public class LanguageService(TogrulDB _context,IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if(await _context.Languages.AnyAsync(x=>x.Code == dto.Code))
            {
                throw new LanguageExistException();
            }
            await _context.AddAsync(new Entities.Language
            {
                LanguageName = dto.LanguageName,
                Icon=dto.Icon,      
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages
                .Include(x => x.Words)
                .Select(x => new LanguageGetDto
                {
                    Code = x.Code,
                    Icon = x.Icon,
                    LanguageName = x.LanguageName,
                    Words = x.Words.Select(x => x.Text).ToList()
                }).ToListAsync();
        }

        public async Task<LanguageGetDto> GetByIdAsync(string? code)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (data == null)
                throw new LanguageNotFoundException();

            var dto = new LanguageGetDto
            {
                Code = data.Code,
                Icon = data.Icon,
                LanguageName = data.LanguageName,
            };
            return dto;
        }

        public async Task<bool> UpdateAsync(string code, LanguageUpdateDto dto)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);

            if (data == null)
            {
                return false;  
            }

            
            data.Icon = dto.Icon;
            data.LanguageName = dto.LanguageName;

            
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0; 
        }

        public async Task DeleteAsync(string? code)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (data != null)
            {
                _context.Languages.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
