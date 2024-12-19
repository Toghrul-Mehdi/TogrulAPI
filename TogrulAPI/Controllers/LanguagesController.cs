using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TogrulAPI.DTOs.Language;
using TogrulAPI.Services.Abstracts;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id,LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
