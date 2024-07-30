using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineStore.Contracts;
using OnlineStore.Models;
using OnlineStore.Models.DbModels;
using OnlineStore.Services;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private OnlineStoreContext db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }
         
        public IActionResult Index()
        {
            return Redirect("/rackets");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
