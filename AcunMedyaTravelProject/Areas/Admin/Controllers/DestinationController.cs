using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AcunMedyaTravelProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly AppDbContext _context;

        public DestinationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var destinations = _context.Destinations.ToList();
            return View(destinations);
        }
        [HttpGet]
        public IActionResult Create()
        {
            // Ülkeleri ViewBag ile gönder
            ViewBag.Countries = _context.Countries
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination destination)
        {
            // CountryId'nin geçerli bir ülkeye ait olup olmadığını kontrol et
            var countryExists = _context.Countries.Any(c => c.Id == destination.CountryId);
            if (!countryExists)
            {
                // Eğer geçerli bir ülke yoksa hata mesajı ekle
                ViewBag.ErrorMessage = "Geçerli bir ülke seçmelisiniz.";
                ViewBag.Countries = _context.Countries
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();
                return View(destination);
            }

            // Veritabanına ekle
            _context.Destinations.Add(destination);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }






        [HttpGet]
        public IActionResult Edit(int id)
        {
            var destination = _context.Destinations.FirstOrDefault(d => d.Id == id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [HttpPost]
        public IActionResult Edit(Destination destination)
        {
            
                var existingDestination = _context.Destinations.FirstOrDefault(d => d.Id == destination.Id);
                if (existingDestination == null)
                {
                    return NotFound();
                }

                existingDestination.CityName = destination.CityName;
                existingDestination.CoverImageUrl = destination.CoverImageUrl;
                _context.SaveChanges();

            return Redirect("/Admin/Destination/");
            //return RedirectToAction("Index", "Destination", new { area = "Admin" });

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var destination = _context.Destinations.FirstOrDefault(d => d.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            _context.Destinations.Remove(destination);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

