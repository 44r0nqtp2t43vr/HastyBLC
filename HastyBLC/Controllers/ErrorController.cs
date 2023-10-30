using Microsoft.AspNetCore.Mvc;

namespace HastyBLC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
