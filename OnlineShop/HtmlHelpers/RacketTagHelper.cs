using Microsoft.AspNetCore.Razor.TagHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineStore.HtmlHelpers
{
    [HtmlTargetElement("Racket")]
    public class RacketTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public Contracts.Racket data { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var content = string.Empty;
          
            content += $@"
            <a class='a-racket' href='/racket/{data.Id}'>
                <div class='card' style='width: 18rem;'>
                    <img src='{data.ImageUrl}' class='card-img-top' alt=''>
                    <span class='racket-brand'>
                        {data.Brand}
                    </span>
                    <div class='card-body'>
                        <span class='racket-name'>{data.Name}</span>
                        <div class='racket-price'>{data.Price}$</div>
                    </div>
                </div>
            </a>";

            output.Content.SetHtmlContent(content);
        }
    }
}
