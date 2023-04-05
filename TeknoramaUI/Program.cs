using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();// Api controller endpointlerimi yakalamak için eklemeyi yaptým.
//builder.Services.AddHttpContextAccessor();

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

//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.IsEssential = true;
//});

var app = builder.Build();


//app.UseSession();

app.UseStaticFiles();

app.UseRouting();

//Middlewarelarýn çaðrýlma sýrasýna dikkat ediyorum

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area=Administration}/{controller=Category}/{action=List}/{id?}"
          );//Area için gerekli endpoint tanýmlamasý
    endpoints.MapDefaultControllerRoute();
});



app.Run();
