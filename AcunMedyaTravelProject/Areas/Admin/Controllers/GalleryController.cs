using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;

        public GalleryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Destination verilerini al
            var destinations = _context.Destinations
                .Select(d => new Destination
                {
                    CityName = d.CityName,
                    CoverImageUrl = d.CoverImageUrl
                })
                .ToList();

            return View(destinations);
        }
    }
}