using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TogrulAPI.DTOs.Language;
using TogrulAPI.Entities;
using TogrulAPI.Exceptions;
using TogrulAPI.Services.Language.Abstracts;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if(ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }    
        }

        [HttpGet("{code}")]

        public async Task<IActionResult> Search(string? code)
        {
            var language = await _service.GetByIdAsync(code);

            if(language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Update(string? code,LanguageUpdateDto dto)
        {
            var language = await _service.GetByIdAsync(code);

            if (language == null)
            {
                return NotFound();  
            }

            language.Icon = dto.Icon;
            language.LanguageName = dto.LanguageName;

            var updateSuccess = await _service.UpdateAsync(code, dto);

            if (updateSuccess)
            {
                return Ok(language); 
            }
            else
            {
                return BadRequest("Update ugurlu oldu!"); 
            }
        }

        [HttpDelete("{code}")]

        public async Task<IActionResult> Delete(string? code)
        {
            await _service.DeleteAsync(code);
            return Ok();
        }
    }
}
