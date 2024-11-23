using Microsoft.AspNetCore.Mvc;

namespace Programsko.Controllers
{

    // /Test
    public class TestController : Controller
    {

        // /Test
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jozo()
        {
            return View();
        }
    }
}
