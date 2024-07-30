using Microsoft.AspNetCore.Mvc;
using OnlineStore.Contracts;
using OnlineStore.SQL;

namespace OnlineStore.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        [Route("/image/edit")]
        public void EditImage( ImageEdit imageEdit)
        {
            SQLQueries.EditImage(imageEdit);
        }

        [HttpPost]
        [Route("/image/remove")]
        public void RemoveImage(string id)
        {
            Console.WriteLine("delete");
            SQLQueries.RemoveImage(id);
        }

        [HttpGet]
        [Route("/image")]
        public async Task<JsonResult> GetImage(string id) {
            var res = await SQLQueries.GetImageUrl(id);

            Console.WriteLine(res);

            return  Json(res);
        }

        [HttpPost]
        [Route("/image/add")]
        public void AddImage(ImageAdd image)
        {
            SQLQueries.addImageToRacket(image);
            Console.WriteLine("id " + image.racket_id + "\nurl " + image.ImageUrl);
        }
    }
}
