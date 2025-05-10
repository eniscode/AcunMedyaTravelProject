using Microsoft.AspNetCore.Mvc;
using AcunMedyaTravelProject.Entities;
using AcunMedyaTravelProject.Enums;
using AcunMedyaTravelProject.Context;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourController : Controller
    {
        private readonly AppDbContext _context;

        public TourController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tours = _context.Tours.ToList();
            return View(tours);
        }

        public IActionResult Create()
        {
            ViewBag.TourCategories = Enum.GetValues(typeof(TourCategory));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Tours.Add(tour);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TourCategories = Enum.GetValues(typeof(TourCategory));
            return View(tour);
        }

        public IActionResult Edit(int id)
        {
            var tour = _context.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewBag.TourCategories = Enum.GetValues(typeof(TourCategory));
            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Tours.Update(tour);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TourCategories = Enum.GetValues(typeof(TourCategory));
            return View(tour);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var tour = _context.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            _context.Tours.Remove(tour);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
