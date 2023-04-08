using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.AppuserModel;
using TeknoramaUI.Models.BasketModel;

namespace TeknoramaUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();

            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken").Value;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
        public async Task<IActionResult> List()
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Baskets");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<BasketListResponseModel> list = JsonSerializer.Deserialize<List<BasketListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (var item in list)
                {
                    //Kullanıcya ait baskete gitme amacındayım
                    var responseAppUser = await client.GetAsync($"http://localhost:5288/api/AppUsers/" + item.AppUserId);
                    var appUserJsonString = await responseAppUser.Content.ReadAsStringAsync();
                    var appUser = JsonSerializer.Deserialize<AppUserListResponseModel>(appUserJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.AppUser = appUser;
                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Create()
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/AppUsers");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<AppUserListResponseModel> appUserList = JsonSerializer.Deserialize<List<AppUserListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                ViewBag.AppUser = new SelectList(appUserList, "Id", "UserName");
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BasketCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/Baskets", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            var response = await client.GetAsync("http://localhost:5288/api/Baskets/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var basketModel = JsonSerializer.Deserialize<BasketUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var responseAppUser = await client.GetAsync("http://localhost:5288/api/AppUsers");
                if (responseAppUser.IsSuccessStatusCode)
                {
                    var appUserJsonString = await responseAppUser.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<List<AppUserListResponseModel>>(appUserJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    ViewBag.AppUser = new SelectList(list, "Id", "UserName");
                    return View(basketModel);
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BasketUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5288/api/Baskets", requestContent);
                return RedirectToAction("List");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync($"http://localhost:5288/api/Baskets/{id}");
            return RedirectToAction("List");
        }
    }
}
