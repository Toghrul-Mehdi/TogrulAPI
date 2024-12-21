using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TogrulAPI.DTOs.BannedWord;
using TogrulAPI.Services.BannedWord.Abstracts;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordController(IBannedWordService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BannedWordCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , BannedWordUpdateDto dto)
        {
            var bannedwords = await _service.GetByIdAsync(id);
            if(bannedwords == null)
            {
                return NotFound();
            }
            bannedwords.Text = dto.Text;
            bannedwords.WordId = dto.WordId;

            var updatedSuccess = await _service.UpdateAsync(id, dto);
            if (updatedSuccess)
            {
                return Ok(bannedwords);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
