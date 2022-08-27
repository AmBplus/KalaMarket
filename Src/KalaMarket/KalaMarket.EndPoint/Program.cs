using KalaMarket.EndPoint.Infrastructure.Settings;
using KalaMarket.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
