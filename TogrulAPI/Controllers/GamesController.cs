using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TogrulAPI.DTOs.Game;
using TogrulAPI.Services.Game.Abstracts;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service,IMemoryCache _cache) : ControllerBase
    {    

        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpGet("Start/{id}")]

        public async Task<IActionResult> Start(Guid id)
        {
            return Ok(await _service.Start(id));
        }
    }
}
