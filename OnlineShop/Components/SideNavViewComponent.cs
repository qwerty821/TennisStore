using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Components
{
    public class SideNavViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("SideNav");
        }

        
    }
}
