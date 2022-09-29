using KalaMarket.EndPoint.Infrastructure.Security;
using KalaMarket.EndPoint.Infrastructure.Settings;
using KalaMarket.Infrastructure;
using KalaMarket.Infrastructure.Product;
using KalaMarket.Infrastructure.User;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string myCorsPolicy = "MyCors";

#region try Add Services

try
{
 
    #region NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    #endregion /NLog

    #region Routing
    builder.Services.AddRouting(op =>
    {
        op.LowercaseUrls = true;
        op.LowercaseQueryStrings = true;
    });
    #endregion /Routing
    builder.Services.AddControllers();
    builder.Services.AddRazorPages();

    #region Athentication

    builder.Services.AddAuthentication(op =>
    {
        op.DefaultAuthenticateScheme = Utility.AuthenticationScheme;
        op.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    }).AddCookie(option =>
    {
        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        option.LoginPath = "/Account/Login";
        option.LogoutPath = "/Account/Logout";
        option.AccessDeniedPath = "/Account/AccessDenied";
        option.SlidingExpiration = true;
        option.Cookie.Name = Utility.KalaMarketAuthCookieName;
    });

    #endregion /Athentication

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

    #region Configure ApplicationSettings Class Service

    builder.Services.Configure<ApplicationSettings>
            (builder.Configuration.GetSection(key: ApplicationSettings.KeyName))
        .AddSingleton
        (implementationFactory: serviceType =>
        {
            var result =
                // GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
                serviceType.GetRequiredService
                <IOptions
                    <ApplicationSettings>>().Value;

            return result;
        });

    #endregion /Configure ApplicationSettings Class Service

    #region Cors

    //builder.Services.AddCors(options =>
    //{
    //    options.AddPolicy(myCorsPolicy,
    //        b=>b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    //    );
    //});

    #endregion



    string connection = builder.Configuration.GetConnectionString("ConnectionSql");

    // Add Application And Db Services
    builder.Services.ConfigureServices(connection);
    builder.Services.ConfigureUserServices();
    builder.Services.ConfigureProductServices();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.

#region Middlewares

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseCors(myCorsPolicy);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

#region MapControllers

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion
app.MapRazorPages();
app.MapGet("/", async (context) =>
{
    context.Response.Redirect("/Site/Index");
});
app.Run();


#endregion