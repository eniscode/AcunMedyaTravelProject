using AcunMedyaTravelProject.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultPackageComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultPackageComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var packages = _context.Packages.ToList();
            return View(packages);
        }
    }
}