using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultTourComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultTourComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var nationalTours = _context.Tours.ToList();
            var countries = _context.Countries.ToList();
            var model = new TourViewModel
            {
                Countries = countries,
                Tours = nationalTours
            };

            return View(model);
        }
    }
}