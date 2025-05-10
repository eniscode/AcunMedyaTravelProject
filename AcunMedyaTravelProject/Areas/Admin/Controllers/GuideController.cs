using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly AppDbContext _context;

        public GuideController(AppDbContext context)
        {
            _context = context;
        }

        // Rehberleri listeleme
        public IActionResult Index()
        {
            var guides = _context.Guides.ToList();
            return View(guides);
        }

        // Yeni rehber ekleme (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni rehber ekleme (POST)
        [HttpPost]
        public IActionResult Create(Guide guide)
        {
            if (ModelState.IsValid)
            {
                _context.Guides.Add(guide);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guide);
        }

        // Rehber düzenleme (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var guide = _context.Guides.FirstOrDefault(g => g.Id == id);
            if (guide == null)
            {
                return NotFound();
            }
            return View(guide);
        }

        // Rehber düzenleme (POST)
        [HttpPost]
        public IActionResult Edit(Guide guide)
        {
           
            
                var existingGuide = _context.Guides.FirstOrDefault(g => g.Id == guide.Id);
                if (existingGuide == null)
                {
                    return NotFound();
                }

                existingGuide.Name = guide.Name;
                existingGuide.Title = guide.Title;
                existingGuide.ImageUrl = guide.ImageUrl;

                _context.SaveChanges();
                return Redirect("/Admin/Guide/");
            

           
        }

        // Rehber silme
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var guide = _context.Guides.FirstOrDefault(g => g.Id == id);
            if (guide == null)
            {
                return NotFound();
            }

            _context.Guides.Remove(guide);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
