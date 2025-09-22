using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.ViewComponents.Blog
{
    public class _BlogSubscriberComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
