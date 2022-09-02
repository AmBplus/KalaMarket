using KalaMarket.EndPoint.Infrastructure.Security;
using KalaMarket.EndPoint.Infrastructure.Settings;
using KalaMarket.Infrastructure;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string myCorsPolicy = "MyCors";
builder.Services.AddRouting(op =>
{
    op.LowercaseUrls = true;
    op.LowercaseQueryStrings = true;
});
builder.Services.AddControllers();
builder.Services.AddRazorPages();
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
    //.AddGoogle(op =>
    //{
    //    op.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    //    op.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    //    op.SaveTokens = true;
    //});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

#region CodeForCors

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(myCorsPolicy,
//        b=>b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//    );
//});

#endregion
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
