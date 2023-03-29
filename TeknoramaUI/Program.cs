using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();// Api controller endpointlerimi yakalamak i�in eklemeyi yapt�m.

//Token ayarlamalar� ger�ekle�tirilir
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    //hangi path ile login olucag�n�, sisteme tan�tt�m
    opt.LoginPath = "/Account/SignIn";
    opt.LogoutPath = "/Account/LogOut";
    opt.AccessDeniedPath = "/Account/AccessDenied";
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "JwtCookie";
});

var app = builder.Build();

app.UseRouting();

//Middlewarelar�n �a�r�lma s�ras�na dikkat ediyorum

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );//Area i�in gerekli endpoint tan�mlamas�
    endpoints.MapDefaultControllerRoute();
});



app.Run();
