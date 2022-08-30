using KalaMarket.EndPoint.Infrastructure.Settings;
using KalaMarket.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string myCorsPolicy = "MyCors";
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.Configure<ApplicationSettings>
        (builder.Configuration.GetSection(key: ApplicationSettings.KeyName))
    // AddSingleton()-> using Microsoft.Extensions.DependencyInjection;
    .AddSingleton
    (implementationFactory: serviceType =>
    {
        var result =
            // GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
            serviceType.GetRequiredService
            <Microsoft.Extensions.Options.IOptions
                <ApplicationSettings>>().Value;

        return result;
    });
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(myCorsPolicy,
//        b=>b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//    );
//});
string connection = builder.Configuration.GetConnectionString("ConnectionSql");
builder.Services.ConfigureServices(connection);
var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthorization();
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
