using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TogrulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Create()
        {
            return Ok("Getdim");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Getdim");
        }
    }
}
