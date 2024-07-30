using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Contracts;
using OnlineStore.Models.DbModels;
using OnlineStore.Repositories;
using OnlineStore.Services;

namespace OnlineShop.Controllers
{
    public class BrandsController : Controller
    {
        private readonly BrandService _brandService;
        public BrandsController(BrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [Route("/brands")]
        public IActionResult Index()
        {
             
            return View();
        }


        [HttpGet]
        [Route("/get-brands")]
        public async Task<JsonResult> GetBrands()
        {
            var l = _brandService.GetAll()
                    .Result
                    .Select(b => new BrandResponse(b.BName, b.BImage));
            return Json(l);
        }

    }
}
