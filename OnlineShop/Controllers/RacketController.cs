using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Contracts;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;
using OnlineStore.Services;
using OnlineStore.SQL;

namespace OnlineShop.Controllers
{
    public class RacketController : Controller
    {
        private readonly RacketService _racketService;
        private readonly BrandService _brandService;

        public RacketController(RacketService racketService, BrandService brandService)
        {
            _racketService = racketService;
            _brandService = brandService;
        }

        [HttpGet]
        [Route("/racket/{id}")]
        public IActionResult Index(string id)
        {
            Console.WriteLine(id);
            return View();
        }

        [HttpGet]
        [Route("/insert-rackets")]
        public async Task<IActionResult> InsertRackets()
        {
            return Content("Ok");
        }

        [HttpGet]
        [Route("/rackets")]
        public async Task<IActionResult> Rackets()
        {
            var rackets = await _racketService.GetAll();

            _brandService.Get(rackets[0].RBrand ?? new Guid());

            return View();
        }

        [HttpGet]
        [Route("/all-rackets")]
        public async Task<JsonResult> GetRacketsByFilter([FromQuery] BrandRequest request)
        {

            if (request.brands.IsNullOrEmpty() && request.SortOption.IsNullOrEmpty())
            {
                return await GetAllRackets();
            }

            FilterOptions filterOptions = new FilterOptions();
            filterOptions.Brands = request.brands?.Split(',').ToList();
            filterOptions.Sort = request.SortOption switch
            {
                "def" => SortOption.None,
                "asc" => SortOption.Ascending,
                "desc" => SortOption.Descending,
                _ => SortOption.None
            };

            var rackets = await _racketService.GetAll(filterOptions);

            List<RacketResponse> response = new List<RacketResponse>();
            foreach (Racket r in rackets)
            {
                Brand brand = (await SQLQueries.getBrand(r.RBrand ?? Guid.Empty));
                response.Add(new RacketResponse(r.RId, r.RName, brand.BName, r.RPrice, r.RImageUrl));
            }
            return Json(response);
        }

        [Route("/get-racket")]
        public async Task<JsonResult> GetRacket([FromQuery] RacketRequest request)
        {
            var racket = await _racketService.Get(request.Id);
            await Console.Out.WriteLineAsync(racket.RName);
            return Json(racket);
        } 
        public async Task<JsonResult> GetAllRackets()
        {
            var rackets = await _racketService.GetAll();

            List<RacketResponse> response = new List<RacketResponse>();
            foreach (Racket r in rackets)
            {
                Brand brand = (await SQLQueries.getBrand(r.RBrand ?? Guid.Empty));

                response.Add(new RacketResponse(r.RId, r.RName, brand.BName, r.RPrice, r.RImageUrl));
            }

            return Json(response);
        }
    }
}