using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();// Api controller endpointlerimi yakalamak için eklemeyi yaptým.

//Token ayarlamalarý gerçekleþtirilir
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    //hangi path ile login olucagýný, sisteme tanýttým
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

//Middlewarelarýn çaðrýlma sýrasýna dikkat ediyorum

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );//Area için gerekli endpoint tanýmlamasý
    endpoints.MapDefaultControllerRoute();
});



app.Run();
