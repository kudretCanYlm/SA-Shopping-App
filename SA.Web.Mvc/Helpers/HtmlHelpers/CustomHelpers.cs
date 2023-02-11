using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SA.Application.Contracts.Dtos.Category.SubCategory;
using System.Linq;

namespace SA.Web.Mvc.Helpers.HtmlHelper
{


    public static class CustomHelpers
    {
        public static IHtmlContent CategoryHelper(this IHtmlHelper helper, SubCategoryWithImageDto categoryView = null)
        {
            


            var coverDiv = new TagBuilder("div");
            coverDiv.AddCssClass("col-lg-3 col-md-4 col-sm-6 pb-1");

            var link = new TagBuilder("a");
            link.AddCssClass("text-decoration-none");
            link.Attributes["href"] = "~/categories/" + categoryView.Id;

            coverDiv.InnerHtml.AppendHtml(link);

            var subdiv_1 = new TagBuilder("div");
            subdiv_1.AddCssClass("cat-item d-flex align-items-center mb-4");

            var subdiv_1_1 = new TagBuilder("div");

            subdiv_1_1.AddCssClass("overflow-hidden");
            subdiv_1_1.Attributes["style"] = "width: 100px; height: 100px;";
            
            var img = new TagBuilder("img");
            img.AddCssClass("img-fluid");
            img.Attributes["src"] = categoryView.Base64Image;

            subdiv_1_1.InnerHtml.AppendHtml(img);
            subdiv_1.InnerHtml.AppendHtml(subdiv_1_1);

            var subdiv_1_2 = new TagBuilder("div");
            var h6 = new TagBuilder("h6");
            h6.InnerHtml.AppendHtml(categoryView.CategoryName);

            var small = new TagBuilder("small");
            small.AddCssClass("text-body");
            small.InnerHtml.Append(categoryView.ProductCount + " Products");

            subdiv_1_2.InnerHtml.AppendHtml(h6);
            subdiv_1_2.InnerHtml.AppendHtml(small);

            subdiv_1.InnerHtml.AppendHtml(subdiv_1_2);

            link.InnerHtml.AppendHtml(subdiv_1);

            using (var writer = new StringWriter())
            {
                coverDiv.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                var output = writer.ToString();
                return new HtmlString(output);
            }



        }
    }
}
