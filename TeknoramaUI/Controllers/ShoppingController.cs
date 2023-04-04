using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.CategoryModel;
using TeknoramaUI.Areas.Administration.Models.ProductModel;
using TeknoramaUI.Areas.Administration.Models.SupplierModel;
using TeknoramaUI.DTO.PaymentDto;
using TeknoramaUI.Models;

namespace TeknoramaUI.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Cart _cart;

        public ShoppingController(IHttpClientFactory httpClientFactory, Cart cart)
        {
            _httpClientFactory = httpClientFactory;
            _cart = cart;
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Products");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<ProductListResponseModel> list = JsonSerializer.Deserialize<List<ProductListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                foreach (var item in list)
                {
                    //Category list yakalama alanı
                    var responseCategory = await client.GetAsync("http://localhost:5288/api/Categories/" + item.CategoryId);
                    var categoryJsonString = await response.Content.ReadAsStringAsync();
                    var category = JsonSerializer.Deserialize<CategoryListResponseModel>(categoryJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    item.Category = category;

                    //Supplier list yakalama alanı
                    var responseSupplier = await client.GetAsync("http://localhost:5288/api/Suppliers/" + item.SupplierId);
                    var supplierJsonString = await response.Content.ReadAsStringAsync();
                    var supplier = JsonSerializer.Deserialize<SupplierListResponseModel>(supplierJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    item.Supplier = supplier;

                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        public IActionResult AddToCart(int id)
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = client.GetAsync($"http://localhost:5288/api/Products/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                var product = JsonSerializer.Deserialize<ProductListResponseModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                var item = new CartItem
                {
                    Id = product.Id,
                    Name = product.ProductName,
                    Price = product.UnitPrice,
                    ImagePath = product.ImagePath
                };
                _cart.AddToCart(item);
            }
            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            return View(_cart.Basket);
        }

        public IActionResult Checkout()
        {
            var paymentDto = new PaymentDTO { ShoppingPrice = _cart.TotalPrice };
            return View(paymentDto);
        }
    }
}
