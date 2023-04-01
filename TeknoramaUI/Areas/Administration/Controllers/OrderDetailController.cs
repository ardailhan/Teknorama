using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.OrderDetailModel;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,BranchManager,SalesRepresentative")]
    public class OrderDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderDetailController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("http://localhost:5288/api/OrderDetails");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<OrderDetailListResponseModel> list = JsonSerializer.Deserialize<List<OrderDetailListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized) return RedirectToAction("Index", "Home");
            else return RedirectToAction("Index", "Home");
        }
    }
}
