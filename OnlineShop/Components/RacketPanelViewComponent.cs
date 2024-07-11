using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Components
{
    public class RacketPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(RacketEntity racket)
        {
            return View("RacketPanel",  racket);
        }
    }
}
