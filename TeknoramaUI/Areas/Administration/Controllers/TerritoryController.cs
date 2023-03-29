using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    public class TerritoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TerritoryController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("http://localhost:5288/api/Territories");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<TerritoryListResponseModel> list = JsonSerializer.Deserialize<List<TerritoryListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized) return RedirectToAction("Index","Home");
            else return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = CreateClient();
            await client.DeleteAsync($"http://localhost:5288/api/Territories/{id}");
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View(new TerritoryCreateRequestModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TerritoryCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var client = CreateClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5288/api/Territories", requestContent);
                return RedirectToAction("List");
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5288/api/Territories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                TerritoryUpdateRequestModel territoryModel = JsonSerializer.Deserialize<TerritoryUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                return View(territoryModel);
            }
            return RedirectToAction("List");
        }
        [HttpPut]
        public async Task<IActionResult> Update(TerritoryUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("http://localhost:5288/api/Territories", requestContent);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}
