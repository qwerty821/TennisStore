using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.RacketsModels
{
    public class AddRacketModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType("integer")]
        public string Price { get; set; }

        [Required]
        [InvalidImageUrl(ErrorMessage = "Image url is not valid")]
        public string ImageUrl { get; set; }

        [Required]
        [InvalidString(ErrorMessage = "Please select a brand")]
        public string Brand { get; set; }

    }

    public class InvalidStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((string)value == "Null")
            {
                return false;
            }
            return true;
        }
    }

    public class InvalidImageUrl : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            string url = (string)value ?? "https://example.com/111";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage resp =  client.Send(new HttpRequestMessage(HttpMethod.Get,""));

            if (resp.StatusCode == System.Net.HttpStatusCode.OK &&
                resp.Content.Headers.ContentType?.MediaType == "image/jpeg")
            {
                return true;
            }
            return false;

        }
    }
}
