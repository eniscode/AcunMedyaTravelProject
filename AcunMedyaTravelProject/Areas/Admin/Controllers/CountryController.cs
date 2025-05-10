using Microsoft.AspNetCore.Mvc;
using AcunMedyaTravelProject.Entities;
using AcunMedyaTravelProject.Context;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.ToList();
            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        public IActionResult Edit(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(country);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        public IActionResult Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
