using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _AdminLayoutContentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

