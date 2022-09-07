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
            person person = new person()
            {
                id = 2,
                DateTimeNow = DateTime.Now,
                name = "reza"
            };
            test.list.Add(person);
           await Logger.LogInformation("User Added {person}", person);
        }
     
    }

    public class test
    {
        public static List<person> list = new List<person>()
        {
            new person()
            {
                name = "amir",
                DateTimeNow = DateTime.Now,
                id = 1
            }
        };
    }

    public class person
    {
        public long id { get; set; }
        public string name { get; set; }
        public DateTime DateTimeNow { get; set; }
    }
}
