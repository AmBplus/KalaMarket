using KalaMarket.EndPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KalaMarket.EndPoint.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _logger.LogDebug("1", "NLog Injected Into Home Controller");
            try
            {

            }
            catch (Exception e)
            {
                logger.LogDebug("");
                logger.LogDebug();
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task OnGet()
        {
            _logger.LogInformation("Hello , This is OnGet Method Of Main");
            Task task = new Task(print);
            task.Start();
        }
        public async void print()
        {
            Task.Delay(5000);
            for (int i = 0; i < 100000; i++)
            {
                _logger.LogInformation($"hooooooooooo{i}");
            }
        }
    }
}