using System.ComponentModel.DataAnnotations;
using KalaMarket.Application.Agg.Services;
using KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;
using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Filters.ModelState;
using Shared.AspNetCore.Infrastructure;
using Shared.AspNetCore.ValidateAttribute;

namespace KalaMarket.EndPoint.Areas.Admin.Pages.HomePages.Sliders;

[ValidateModelRazorPage]
public class NewSliderModel : BasePageModel
{
    public NewSliderModel(IKalaMarketAggServices kalaMarketAggServices)
    {
        KalaMarketAggServices = kalaMarketAggServices;
    }

    private IKalaMarketAggServices KalaMarketAggServices { get; }

    [BindProperty] public SliderType SliderTypeProperty { get; set; }

    [BindProperty]
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Link))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [MaxLength(KalaMarketConstants.MaxLength.Name * 2, ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.MaxLen))]
    public string Link { get; set; }

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Image))]
    [FileAcceptExtensions(new[]
    {
        KalaMarketConstants.ImageExtension.Jpg, KalaMarketConstants.ImageExtension.Jpeg,
        KalaMarketConstants.ImageExtension.Png,
        KalaMarketConstants.ImageExtension.Webp
    })]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [BindProperty]
    public IFormFile Image { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost([FromServices] IKalaMarketAggServices kalaMarketService
        , [FromServices] IWebHostEnvironment hostEnvironment, [FromServices] ILoggerManger logger
    )
    {
        // Save Image
        string imagePath = await Image.SaveFormFile(hostEnvironment, KalaMarketConstants.FolderPath.SlidersPath);
        if (!CheckISValidImage(imagePath)) return Page();
        // Add Slider
        var result = kalaMarketService.HomePageAggFacadeService.Slider.Cmd.AddSliderService.Execute(
            new RequestAddSliderServiceDto
            {
                Link = Link,
                Src = imagePath,
                SliderType = SliderTypeProperty
            });
        // Check Result
        if (result.IsSuccess == false)
        {
            await RemoveFileHelper.RemoveFile(hostEnvironment, imagePath, logger);
            AddToastError(result.Message);
        }
        else
        {
            AddToastSuccess(result.Message);
        }

        return RedirectToPage("index");
    }

    /// <summary>
    ///     If ImagePath IsNullOrWhiteSpace Mean Image File Is Invalid
    /// </summary>
    /// <param name="imagePath"></param>
    /// <returns></returns>
    private bool CheckISValidImage(string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath)) return false;
        return true;
    }
}