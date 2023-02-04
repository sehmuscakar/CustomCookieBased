using CustomCookieBased.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CookieContext>(opt =>
{
    opt.UseSqlServer("server=DESKTOP-O9RRR03;database=CookieDb; TrustServerCertificate=True; integrated security=true");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "CustomCookie";
    opt.Cookie.HttpOnly= true;
    opt.Cookie.SameSite = SameSiteMode.Strict;// cookieyi payla�amaya kapat�yroduk 
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//nas�l geldiyse oyle olu�sun http ise http ,htpps ise htpps ile 
    opt.ExpireTimeSpan=TimeSpan.FromDays(10);// 10 g�m baounca bunu tut
    opt.LoginPath = new PathString("/Home/SignIn");
    opt.LogoutPath = new PathString("/Home/LogOut");
    opt.AccessDeniedPath = new PathString("/Home/AccessDeniled");
});  
builder.Services.AddControllersWithViews();
var app = builder.Build();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.Run();
