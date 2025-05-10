using Microsoft.AspNetCore.Mvc;
using AcunMedyaTravelProject.Context;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tourCount = _context.Tours.Count();
            var countryCount = _context.Countries.Count();
            var guideCount = _context.Guides.Count();

            ViewBag.TourCount = tourCount;
            ViewBag.CountryCount = countryCount;
            ViewBag.GuideCount = guideCount;

            return View();
        }
    }
}
