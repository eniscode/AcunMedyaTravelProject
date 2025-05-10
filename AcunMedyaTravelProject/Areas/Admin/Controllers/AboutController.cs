using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var abouts = _context.Abouts.ToList();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                _context.Abouts.Add(about);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Hakkımızda bilgisi başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Hakkımızda bilgisi eklenirken bir hata oluştu.";
            return View(about);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var about = _context.Abouts.FirstOrDefault(a => a.Id == id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                var existingAbout = _context.Abouts.FirstOrDefault(a => a.Id == about.Id);
                if (existingAbout == null)
                {
                    return NotFound();
                }

                existingAbout.Name = about.Name;
                existingAbout.Description = about.Description;
                existingAbout.ImageUrl = about.ImageUrl;

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Hakkımızda bilgisi başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Hakkımızda bilgisi güncellenirken bir hata oluştu.";
            return View(about);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var about = _context.Abouts.FirstOrDefault(a => a.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            _context.Abouts.Remove(about);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Hakkımızda bilgisi başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
