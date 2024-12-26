using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TabuWebUI.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
