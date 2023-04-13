using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.EmployeeModel;
using TeknoramaUI.Areas.Administration.Models.EmployeeTerritoryModel;
using TeknoramaUI.Areas.Administration.Models.TerritoryModel;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeTerritoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeTerritoryController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/EmployeeTerritories");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<EmployeeTerritoryListResponseModel> list = JsonSerializer.Deserialize<List<EmployeeTerritoryListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

                foreach ( var item in list)
                {
                    //Employee list
                    var responseEmployee = await client.GetAsync($"http://localhost:5288/api/Employees{item.EmployeeId}");
                    var employeeJsonString = await responseEmployee.Content.ReadAsStringAsync();
                    var employee = JsonSerializer.Deserialize<EmployeeListResponseModel>(employeeJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.Employee = employee;

                    //Territory list
                    var responseTerritory = await client.GetAsync($"http://localhost:5288/api/Territories{item.TerritoryId}");
                    var territoryJsonString = await responseTerritory.Content.ReadAsStringAsync();
                    var territory = JsonSerializer.Deserialize<TerritoryListResponseModel>(territoryJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    item.Territory = territory;
                }
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) return RedirectToAction("AccessDenied", "Account");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Employees");
            if (response.IsSuccessStatusCode)
            {
                //Get employees
                string employeejsonString = await response.Content.ReadAsStringAsync();
                List<EmployeeListResponseModel> employeeList = JsonSerializer.Deserialize<List<EmployeeListResponseModel>>(employeejsonString,new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

                ViewBag.Employees = new SelectList(employeeList, "Id", "FirstName", "LastName", "MonthlySales");

                //Get territories
                string territoryjsonString = await response.Content?.ReadAsStringAsync();
                List<TerritoryListResponseModel> territoryList = JsonSerializer.Deserialize<List<TerritoryListResponseModel>>(territoryjsonString,new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

                ViewBag.Territories = new SelectList(territoryList, "Id", "TerritoryDescription");

                return View();
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTerritoryCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/EmployeeTerritories", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
    }
}
