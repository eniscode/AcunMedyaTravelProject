using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController : Controller
    {
        private readonly AppDbContext _context;

        public SocialController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var socialMedias = _context.SocialMedias
                .Include(sm => sm.Guide) // Guide ilişkisini dahil ediyoruz
                .ToList();
            return View(socialMedias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Guides = _context.Guides
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(SocialMedia socialMedia)
        {
            var guideExists = _context.Guides.Any(g => g.Id == socialMedia.GuideId);
            if (!guideExists)
            {
                ViewBag.ErrorMessage = "Geçerli bir rehber seçmelisiniz.";
                ViewBag.Guides = _context.Guides
                    .Select(g => new SelectListItem
                    {
                        Value = g.Id.ToString(),
                        Text = g.Name
                    }).ToList();
                return View(socialMedia);
            }

            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var socialMedia = _context.SocialMedias.FirstOrDefault(sm => sm.Id == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            ViewBag.Guides = _context.Guides
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                }).ToList();

            return View(socialMedia);
        }

        [HttpPost]
        public IActionResult Edit(SocialMedia socialMedia)
        {
            var existingSocialMedia = _context.SocialMedias.FirstOrDefault(sm => sm.Id == socialMedia.Id);
            if (existingSocialMedia == null)
            {
                return NotFound();
            }

            existingSocialMedia.Icon = socialMedia.Icon;
            existingSocialMedia.Url = socialMedia.Url;
            existingSocialMedia.GuideId = socialMedia.GuideId;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var socialMedia = _context.SocialMedias.FirstOrDefault(sm => sm.Id == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            _context.SocialMedias.Remove(socialMedia);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
