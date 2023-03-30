using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    public class IssueController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IssueController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Issues");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<IssueListResponseModel> list = JsonSerializer.Deserialize<List<IssueListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                foreach(var item in list)
                {
                    //AppUser liste ulaşıyorum
                    var responseAppUser = await client.GetAsync("http://localhost:5288/api/AppUsers" + item.AppUserId);
                    var appUserJsonString = await responseAppUser.Content.ReadAsStringAsync();
                    var appUser = JsonSerializer.Deserialize<AppUserListResponseModel>(appUserJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.AppUser = appUser;
                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = CreateClient();
            await client.DeleteAsync($"http://localhost:5288/api/Issues/{id}");
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Create()
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/AppUsers");
            if (response.IsSuccessStatusCode)
            {
                // Get AppUsers
                string jsonString = await response.Content.ReadAsStringAsync();
                List<AppUserListResponseModel> appUserList = JsonSerializer.Deserialize<List<AppUserListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                ViewBag.AppUser = new SelectList(appUserList, "Id", "UserName");

                return View();
            }
            else return RedirectToAction("Index","Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IssueCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/Issues", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            var response = await client.GetAsync($"http://localhost:5288/api/Issues/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var issueModel = JsonSerializer.Deserialize<IssueUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var responseAppUser = await client.GetAsync("http://localhost:5288/api/AppUsers");
                if (responseAppUser.IsSuccessStatusCode)
                {
                    var appUserJsonString = await responseAppUser.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<List<AppUserListResponseModel>>(appUserJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    ViewBag.AppUsers = new SelectList(list, "Id", "UserName", "Email");
                    return View(issueModel);
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Update(IssueUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5288/api/Issues", requestContent);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
