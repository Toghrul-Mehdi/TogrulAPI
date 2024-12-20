using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TogrulAPI.DAL;
using TogrulAPI.DTOs.Language;
using TogrulAPI.Services.Abstracts;

namespace TogrulAPI.Services.Implements
{
    public class LanguageService(TogrulDB _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Icon = dto.Icon,
                LanguageName = dto.LanguageName,    
            }); 
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x=> new LanguageGetDto
            {
                Code = x.Code,
                Icon = x.Icon,
                LanguageName = x.LanguageName,
            }).ToListAsync();
        }

        public async Task UpdateAsync(string? code, LanguageUpdateDto dto)
        {
            var data  = await _context.Languages.FirstOrDefaultAsync(x=>x.Code == code);
            if (data != null)
            {
                data.Icon = dto.Icon;
                data.LanguageName = dto.LanguageName;
                
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task DeleteAsync(string? code)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x=>x.Code ==code);
            if(data != null)
            {
                _context.Languages.Remove(data);   
                await _context.SaveChangesAsync();
            }
        }
    }
}
