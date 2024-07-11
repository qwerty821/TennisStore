using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.DbModels;

namespace OnlineShop.Controllers
{
    public class BrandsController : Controller
    {
        public BrandsController( )
        {
             
        }

        [HttpGet]
        [Route("/brands")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
