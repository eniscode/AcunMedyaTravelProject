using AcunMedyaTravelProject.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DestinationViewComponents
{
    public class _DestinationCityComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DestinationCityComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var destinations = _context.Destinations.ToList();
            var countries = _context.Countries.ToList();

            var model = (destinations, countries);

            return View(model);
        }
    }
}