using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaTravelProject.ViewComponents.DefaultViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
