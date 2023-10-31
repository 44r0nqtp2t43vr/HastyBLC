using Microsoft.AspNetCore.Mvc;

namespace HastyBLCAdmin.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
