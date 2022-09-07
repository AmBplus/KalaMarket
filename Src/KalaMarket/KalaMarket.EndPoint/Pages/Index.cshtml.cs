using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Infrastructure;
using KalaMarket.Shared;
namespace KalaMarket.EndPoint.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly ILoggerManger<IndexModel> Logger;
        public IndexModel(ILoggerManger<IndexModel> logger)
        {
            Logger = logger;
        }
        public async Task OnGet()
        {
          
        }
     
    }

 

    
}
