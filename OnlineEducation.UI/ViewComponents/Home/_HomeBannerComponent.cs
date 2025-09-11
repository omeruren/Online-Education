using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.UI.ViewComponents.Home
{
    public class _HomeBannerComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
