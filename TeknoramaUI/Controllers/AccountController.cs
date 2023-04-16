using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Models;

namespace TeknoramaUI.Controllers
{
    public class AccountController : Controller
    {
        //Api ile iletişim kurabilmek için IHttpClientFactory arayüzünü kullanıyorum
        //Bunun sayesinde bir client oluşturup, auth controller içerisindeki login işlemlerini gerçekleştirebiliyorum
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel model)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5288/api/Auth/SignIn", requestContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                JwtResponseModel tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel.Token);

                if (token != null)
                {
                    var roles = token.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
                    //if (roles.Contains("Admin"))
                    //    {
                    //        return RedirectToAction("List", "Category", new { area = "Administration" });

                    //    }
                    var claims = token.Claims.ToList();
                    claims.Add(new Claim("accessToken", tokenModel.Token == null ? "" : tokenModel.Token));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                    var auhtProps = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), auhtProps);
                    return RedirectToAction("Create", "Basket");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is invalid");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is invalid");
                return View(response);
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5288/api/Auth/Register", requestContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                ModelState.AddModelError("", "Registration failed");
                return View(model);
            }
        }

    }
}
//API Url = http://localhost:5288/api/Auth/SignIn
//UI Url = http://localhost:5101/