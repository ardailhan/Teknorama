using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.AppRoleModel;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppRoleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppRoleController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/AppRoles");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<AppRoleListResponseModel> list = JsonSerializer.Deserialize<List<AppRoleListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized) return RedirectToAction("Index", "Home");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = CreateClient();
            await client.DeleteAsync($"http://localhost:5288/api/AppRoles{id}");
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new AppRoleCreateRequestModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppRoleCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/AppRoles", requestContent);
                return RedirectToAction("List");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            var response = await client.GetAsync($"http://localhost:5288/api/AppRoles{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                AppRoleUpdateRequestModel appRoleModel = JsonSerializer.Deserialize<AppRoleUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                return View(appRoleModel);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AppRoleUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("http://localhost:5288/api/AppRoles", requestContent);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}
