using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("NavBar");
        }
    }
}
