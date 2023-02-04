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
    opt.Cookie.SameSite = SameSiteMode.Strict;// cookieyi paylaþamaya kapatýyroduk 
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//nasýl geldiyse oyle oluþsun http ise http ,htpps ise htpps ile 
    opt.ExpireTimeSpan=TimeSpan.FromDays(10);// 10 güm baounca bunu tut
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
