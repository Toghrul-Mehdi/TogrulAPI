using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TogrulAPI.Entities;

namespace TabuWebUI.Controllers
{
    public class TabuController(TogrulAPI.DAL.TogrulDB _context) : Controller
    {
        public async Task<IActionResult> Create()
        {
            ViewBag.Language = await _context.Languages.ToListAsync();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(TogrulAPI.DTOs.Game.GameCreateDto vm)
        {          

            Game category = new Game
            {
                BannedWordCount = vm.BannedWordCount,
                FailCount = vm.FailCount,
                SkipCount = vm.SkipCount,
                Time = vm.Time,
                LanguageCode = vm.LanguageCode,
            };
            await _context.Games.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
