using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404()
        {
            return View("Error404");
        }
    }
}
