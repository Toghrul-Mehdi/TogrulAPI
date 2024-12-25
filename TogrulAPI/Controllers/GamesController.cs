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
            return Ok(await _service.Start(id));
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Skip(Guid id)
        {
            return Ok(await _service.Skip(id));
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Success(Guid id)
        {
            return Ok(await _service.Success(id));
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> Fail(Guid id)
        {
            return Ok(await _service.Fail(id));
        }
        [HttpPost("[action]")]

        public async Task<IActionResult> End(Guid id)
        {
            return Ok(await _service.End(id));
            
        }
    }
}
