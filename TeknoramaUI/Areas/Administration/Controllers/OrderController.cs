using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.AppuserModel;
using TeknoramaUI.Areas.Administration.Models.EmployeeModel;
using TeknoramaUI.Areas.Administration.Models.OrderModel;
using TeknoramaUI.Areas.Administration.Models.ShipperModel;
using TeknoramaUI.Models.BasketModel;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles ="Admin")]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Orders");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<OrderListResponseModel> list = JsonSerializer.Deserialize<List<OrderListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                foreach (var item in list)
                {
                    //Employee Listlere ulaşıyorum
                    var responseEmployee = await client.GetAsync("http://localhost:5288/api/Employees" + item.EmployeeId);
                    var employeeJsonString = await responseEmployee.Content.ReadAsStringAsync();
                    var employee = JsonSerializer.Deserialize<EmployeeListResponseModel>(employeeJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.Employee = employee;

                    //Shipper Listlere ulaşıyorum

                    var responseShipper = await client.GetAsync("http://localhost:5288/api/Shippers" + item.ShipperId);
                    var shipperJsonString = await responseShipper.Content.ReadAsStringAsync();
                    var shipper = JsonSerializer.Deserialize<ShipperListResponseModel>(shipperJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.Shipper = shipper;

                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        
    }
}
