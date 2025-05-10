using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
