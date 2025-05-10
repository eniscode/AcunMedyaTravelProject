using AcunMedyaTravelProject.Context;
using AcunMedyaTravelProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultGuideComponentPartial : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultGuideComponentPartial(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var guides = await _context.Guides
                .Include(g => g.SocialMedias) // SocialMedia ilişkisini dahil ediyoruz
                .ToListAsync();

            return View(guides);
        }
    }
}
