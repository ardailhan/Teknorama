﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models.ExpenseModel;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExpenseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExpenseController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("http://localhost:5288/api/Expenses");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<ExpenseListResponseModel> list = JsonSerializer.Deserialize<List<ExpenseListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(list);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized) return RedirectToAction("Index", "Home");
            else return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = CreateClient();

            await client.DeleteAsync($"http://localhost:5288/api/Expenses/{id}");

            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View(new ExpenseCreateRequestModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/Expenses", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"http://localhost:5288/api/Expenses/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                ExpenseUpdateRequestModel expenseModel = JsonSerializer.Deserialize<ExpenseUpdateRequestModel>(jsonString, new JsonSerializerOptions
                { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(expenseModel);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ExpenseUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("http://localhost:5288/api/Expenses", requestContent);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}
