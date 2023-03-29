using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,BranchManager")]
    public class ShipperController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShipperController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Shippers");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<ShipperListResponseModel> list = JsonSerializer.Deserialize<List<ShipperListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized) return RedirectToAction("Index", "Home");
            else return RedirectToAction("Index", "Home");
        }
    }
}
