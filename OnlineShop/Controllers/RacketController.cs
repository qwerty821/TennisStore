using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Contracts;
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
        public IActionResult Index(Guid id)
        {
            if (SQLQueries.ExistRacketId(id))
            {
                ViewData["found"] = true;
            } else
            {
                ViewData["found"] = false;
            }

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
        public IActionResult Rackets()
        {
            //var rackets = await _racketService.GetAll();
            //await Console.Out.WriteLineAsync("------------");
            //_brandService.Get(rackets[0].RBrand ?? new Guid());
            //await Console.Out.WriteLineAsync("++++++++++++");

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

            List<OnlineStore.Contracts.Racket> response = new List<OnlineStore.Contracts.Racket>();
            foreach (OnlineStore.Models.RacketsModels.Racket r in rackets)
            {
                Brand brand = (await SQLQueries.getBrand(r.RBrand ?? Guid.Empty));
                response.Add(new OnlineStore.Contracts.Racket(r.RId, r.RName, brand.BName, r.RPrice, r.RImageUrl));
            }
            return Json(response);
        }


        [Route("/get-racket")]
        public async Task<JsonResult> GetRacket([FromQuery] RacketRequest request)
        {
            var racket = await _racketService.Get(request.Id);
            
            var response = new RacketDetailResponse(
                                racket.RId, 
                                racket.RName, 
                                (await SQLQueries.getBrand(racket.RBrand ?? Guid.Empty)).BName, 
                                racket.RPrice, 
                                racket.images, 
                                "description",
                                racket.RImageUrl);

            return Json(response);
        }

        public async Task<JsonResult> GetAllRackets()
        {
            var rackets = await _racketService.GetAll();

            List<OnlineStore.Contracts.Racket> response = new List<OnlineStore.Contracts.Racket>();
            foreach (OnlineStore.Models.RacketsModels.Racket r in rackets)
            {
                Brand brand = (await SQLQueries.getBrand(r.RBrand ?? Guid.Empty));

                response.Add(new OnlineStore.Contracts.Racket(r.RId, r.RName, brand.BName, r.RPrice, r.RImageUrl));
            }

            return Json(response);
        }

        [HttpGet]
        [Route("/add-racket")]
        public IActionResult AddRacket([FromQuery] RacketRequest request)
        {
            return View();
        }

        [HttpPost]
        [Route("/add-racket")]
        public async Task<IActionResult> AddRacket(AddRacketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _racketService.AddRacket(model);

            return Redirect("/");
        }

        [HttpGet]
        [Route("/edit-racket/{id}")]
        public IActionResult EditRacket()
        {
            return View();
        }
        [HttpPost]
        [Route("/edit-racket/{id}")]
        public IActionResult EditRacket(Guid id)
        {
            return View();
        }

       
    }
}