using Microsoft.AspNetCore.Mvc;

namespace TabuWebUI.Controllers
{
    public class TabuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
