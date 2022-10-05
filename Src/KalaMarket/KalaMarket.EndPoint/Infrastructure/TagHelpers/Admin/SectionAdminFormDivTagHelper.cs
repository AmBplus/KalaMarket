using Microsoft.AspNetCore.Razor.TagHelpers;
using Shared.AspNetCore.TagHelpers;

namespace KalaMarket.EndPoint.Infrastructure.TagHelpers.Admin
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(tag: "amb-admin-divForm", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class DivInputAdminTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.AddCssClass("col-xl-4 col-lg-6 col-md-12 mb-1");
            output.PreContent.SetHtmlContent(@"<fieldset class=""form-group"">");
            output.PostContent.SetHtmlContent("</fieldset>");
        }
    }
}
