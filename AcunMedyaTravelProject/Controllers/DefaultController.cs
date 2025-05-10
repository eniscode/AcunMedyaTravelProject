using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AppDbContext _context;

        public DefaultController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}