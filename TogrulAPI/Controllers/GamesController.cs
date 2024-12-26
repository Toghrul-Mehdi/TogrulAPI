using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TogrulAPI.DTOs.Game;
using TogrulAPI.Services.Game.Abstracts;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service) : ControllerBase
    {    

        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Start(Guid id)
        {
            try
            {
                return Ok(await _service.Start(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Bele bir oyun tapilmadi");
            }
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Skip(Guid id)
        {
            try
            {
                return Ok(await _service.Skip(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Bele bir oyun tapilmadi");
            }
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Success(Guid id)
        {
            try
            {
                return Ok(await _service.Success(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Bele bir oyun tapilmadi");
            }
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Fail(Guid id)
        {
            try
            {
                return Ok(await _service.Fail(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Bele bir oyun tapilmadi");
            }
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> End(Guid id)
        {
            try
            {
                return Ok(await _service.End(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Bele bir oyun tapilmadi");
            }
        }
    }
}
