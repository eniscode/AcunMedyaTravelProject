using Microsoft.AspNetCore.Mvc;

using AcunMedyaTravelProject.Entities;
using System.Linq;
using AcunMedyaTravelProject.Context;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;

        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Veritabanından tüm testimonial verilerini çekiyoruz
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
