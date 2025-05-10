using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultServiceComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultServiceComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var services = _context.Services.ToList();

            return View(services);
        }
    }
}