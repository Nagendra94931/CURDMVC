using CURDMVC.RouteServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using CURDMVC.DataModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<EfcoreMvcdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection")));

// Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/AccessDenied";

        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // default expiry
        options.SlidingExpiration = true; // refresh expiry on activity
    });

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


// Redirect root (/) to /User/Login
app.MapGet("/", context =>
{
    context.Response.Redirect("/User/Login");
    return Task.CompletedTask;
});


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");



//Using for Route Configure
RouteConfig.RegisterRoutes(app);


app.Run();

