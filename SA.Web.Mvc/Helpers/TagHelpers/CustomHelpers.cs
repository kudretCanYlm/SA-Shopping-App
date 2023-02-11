using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SA.Application.Contracts.Dtos.Product.Product;
using System.Text;

namespace SA.Web.Mvc.Helpers.TagHelper
{
    [HtmlTargetElement("product-tag-helper")]
    public class CustomHelpers: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public ProductWithImageDto productView { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.TagMode = TagMode.StartTagOnly;

            var sb = new StringBuilder();
            sb.Append($"        <div class=\"col-lg-3 col-md-4 col-sm-6 pb-1\">\r\n   " +
                $"         <div class=\"product-item bg-light mb-4\">\r\n                " +
                $"<div class=\"product-img position-relative overflow-hidden\">\r\n                    " +
                $"<img class=\"img-fluid w-100\" src=\"{productView.Base64Image}\" alt=\"\">\r\n   " +
                $"                 <div class=\"product-action\">\r\n             " +
                $"           <a class=\"btn btn-outline-dark btn-square\" href=\"\"><i class=\"fa fa-shopping-cart\"></i></a>\r\n                        <a class=\"btn btn-outline-dark btn-square\" href=\"\"><i class=\"far fa-heart\"></i></a>\r\n     " +
                $"                   <a class=\"btn btn-outline-dark btn-square\" href=\"\"><i class=\"fa fa-sync-alt\"></i></a>\r\n                        <a class=\"btn btn-outline-dark btn-square\" href=\"\"><i class=\"fa fa-search\"></i></a>\r\n   " +
                $"                 </div>\r\n                </div>\r\n                <div class=\"text-center py-4\">\r\n                    <a class=\"h6 text-decoration-none text-truncate\" href=\"{productView.ProductId}\">{productView.ProductName}</a>\r\n                 " +
                $"   <div class=\"d-flex align-items-center justify-content-center mt-2\">\r\n      " +
                $"                  <h5>$123.00</h5><h6 class=\"text-muted ml-2\"><del>{productView.Price}</del></h6>\r\n        " +
                $"            </div>\r\n                    <div class=\"d-flex align-items-center justify-content-center mb-1\">\r\n         " +
                $"               <small class=\"fa fa-star text-primary mr-1\"></small>\r\n                        <small class=\"fa fa-star text-primary mr-1\"></small>\r\n     " +
                $"                   <small class=\"fa fa-star text-primary mr-1\"></small>\r\n                        <small class=\"fa fa-star text-primary mr-1\"></small>\r\n      " +
                $"                  <small class=\"fa fa-star text-primary mr-1\"></small>\r\n                        <small>({productView.CommentSize})</small>\r\n          " +
                $"          </div>\r\n                </div>\r\n            </div>\r\n        </div>");

           output.PreContent.SetHtmlContent(sb.ToString());

        }
    }


}
