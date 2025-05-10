using AcunMedyaTravelProject.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultBookingComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultBookingComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var packages = _context.Packages.ToList();
            ViewBag.Packages = new SelectList(packages, "Id", "Title");
            return View();
        }
    }
}