using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Shared;

namespace KalaMarket.EndPoint.Pages.Site
{
    public class IndexModel : BasePageModel
    {
        private readonly ILoggerManger<IndexModel> Logger;
        private  ICategoryFacade CategoryService { get; }
        public IndexModel(ILoggerManger<IndexModel> logger, ICategoryFacade categoryService)
        {
            Logger = logger;
            CategoryService = categoryService;
        }
        public async Task OnGet()
        {
        }
     
    }

 

    
}
