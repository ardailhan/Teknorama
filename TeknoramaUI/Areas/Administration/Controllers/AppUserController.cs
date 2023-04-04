using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.AppRoleModel;
using TeknoramaUI.Areas.Administration.Models.AppuserModel;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,BranchManager")]
    public class AppUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppUserController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/AppUsers");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<AppUserListResponseModel> list = JsonSerializer.Deserialize<List<AppUserListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                foreach (var item in list)
                {
                    //AppRole Liste ulaşıyorum
                    var responseAppRole = await client.GetAsync($"http://localhost:5288/api/AppRoles{item.AppRoleId}");
                    var appRoleJsonString = await responseAppRole.Content.ReadAsStringAsync();
                    var appRole = JsonSerializer.Deserialize<AppRoleListResponseModel>(appRoleJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.AppRole = appRole;
                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = CreateClient();
            await client.DeleteAsync($"http://localhost:5288/api/AppUsers/{id}");
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Create()
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/AppRoles");
            if (response.IsSuccessStatusCode)
            {
                //Get AppRoles
                string jsonString = await response.Content.ReadAsStringAsync();
                List<AppRoleListResponseModel> appRoleList = JsonSerializer.Deserialize<List<AppRoleListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                ViewBag.AppRoles = new SelectList(appRoleList, "Id", "Definition");

                return View();
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppUserCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/AppUsers", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            var response = await client.GetAsync($"http://localhost:5288/api/AppUsers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var appUserModel = JsonSerializer.Deserialize<AppUserUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var responseAppRole = await client.GetAsync("http://localhost:5288/api/AppRoles");
                if (responseAppRole.IsSuccessStatusCode)
                {
                    var appRoleJsonString = await responseAppRole.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<List<AppRoleListResponseModel>>(appRoleJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    ViewBag.AppRoles = new SelectList(list, "Id", "Definition");
                    return View(appUserModel);
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5288/api/AppUsers", requestContent);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
