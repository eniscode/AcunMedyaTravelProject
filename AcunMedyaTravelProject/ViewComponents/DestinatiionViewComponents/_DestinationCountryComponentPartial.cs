using AcunMedyaTravelProject.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DestinationViewComponents
{
    public class _DestinationCountryComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DestinationCountryComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var countries = _context.Countries.ToList();
            return View(countries);
        }
    }
}