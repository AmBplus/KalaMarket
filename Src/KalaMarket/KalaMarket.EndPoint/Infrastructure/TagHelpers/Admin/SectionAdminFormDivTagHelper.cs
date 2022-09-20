using _01_Framework.AspCore.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
//< div class= "col-xl-4 col-lg-6 col-md-12 mb-1" >
//    < fieldset class= "form-group" >
//    < label asp -for= "Name" > نام محصول </ label >
//    < input asp -for= "Name" class= "form-control" >
//    < span class= "text-danger" asp - validation -for= "Name" ></ span >
//    </ fieldset >
//    </ div >