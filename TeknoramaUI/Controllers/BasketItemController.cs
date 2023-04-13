using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.ProductModel;
using TeknoramaUI.Models.BasketItemModel;
using TeknoramaUI.Models.BasketModel;

namespace TeknoramaUI.Controllers
{
    public class BasketItemController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketItemController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/BasketItems");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<BasketItemListResponseModel> list = JsonSerializer.Deserialize<List<BasketItemListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                foreach (var item in list)
                {
                    // Get Products
                    var responseProduct = await client.GetAsync($"http://localhost:5288/api/Products/{item.ProductId}");
                    var productJsonString = await responseProduct.Content.ReadAsStringAsync();
                    var product = JsonSerializer.Deserialize<ProductListResponseModel>(productJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.Product = product;

                    //Get Baskets
                    var responseBasket = await client.GetAsync($"http://localhost:5288/api/Baskets/{item.BasketId}");
                    var basketJsonString = await responseBasket.Content.ReadAsStringAsync();
                    var basket = JsonSerializer.Deserialize<BasketListResponseModel>(basketJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.Basket = basket;
                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Create()
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Products");
            if (response.IsSuccessStatusCode)
            {
                //Products
                string jsonString = await response.Content.ReadAsStringAsync();
                List<ProductListResponseModel> productList = JsonSerializer.Deserialize<List<ProductListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                ViewBag.Products = new SelectList(productList, "Id", "ProductName", "UnitPrice", "UnitsInStock");
                //Baskets
                string jsonStringBasket = await response.Content.ReadAsStringAsync();
                List<BasketListResponseModel> basketList = JsonSerializer.Deserialize<List<BasketListResponseModel>>(jsonStringBasket, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                ViewBag.Baskets = new SelectList(basketList, "Id", "AppUserId");
                return View();
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BasketItemCreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/BasketItems", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            var response = await client.GetAsync("http://localhost:5288/api/BasketItems/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var basketItemModel = JsonSerializer.Deserialize<BasketItemUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var responseProduct = await client.GetAsync("http://localhost:5288/api/Products");
                if (responseProduct.IsSuccessStatusCode)
                {
                    var productJsonString = await responseProduct.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<List<ProductListResponseModel>>(productJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    ViewBag.Products = new SelectList(list, "Id", "ProductName", "UnitPrice", "UnitsInStock");

                    var responseBasket = await client.GetAsync("http://localhost:5288/api/Baskets");
                    var basketJsonString = await responseBasket.Content.ReadAsStringAsync();
                    var basketList = JsonSerializer.Deserialize<List<BasketListResponseModel>>(basketJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    ViewBag.Baskets = new SelectList(basketList, "Id", "AppUserId");

                    return View(basketItemModel);
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BasketItemUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5288/api/BasketItems", requestContent);
                return RedirectToAction("List");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = CreateClient();
            await client.DeleteAsync($"http://localhost:5288/api/BasketItems/{id}");
            return RedirectToAction("List");
        }
    }
}
