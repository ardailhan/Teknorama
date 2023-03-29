﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using TeknoramaUI.Areas.Administration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Net;

namespace TeknoramaUI.Areas.Administration.Controllers
{
    [Authorize(Roles ="Admin,BranchManager")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Products");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<ProductListResponseModel> list = JsonSerializer.Deserialize<List<ProductListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                foreach (var item in list)
                {
                    //Category list yakalama alanı !!
                    var responseCategory = await client.GetAsync("http://localhost:5288/api/Categories/" + item.CategoryId);
                    var categoryJsonString = await response.Content.ReadAsStringAsync();
                    var category = JsonSerializer.Deserialize<CategoryListResponseModel>(categoryJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    item.Category = category;

                    //Supplier list yakalama alanı !!
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

        public async Task<IActionResult> Create()
        {
            HttpClient client = CreateClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5288/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                //Categories
                string jsonString = await response.Content.ReadAsStringAsync();
                List<CategoryListResponseModel> catList = JsonSerializer.Deserialize<List<CategoryListResponseModel>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                ViewBag.Categories = new SelectList(catList, "Id", "CategoryName", "Description");

                //Suppliers => Ctrl + R+M ile Method haline getirilebilir !!!
                await GetSuppliers(client);
                return View();
            }
            else return RedirectToAction("Index","Home");
        }

        private async Task GetSuppliers(HttpClient client)
        {
            HttpResponseMessage responseSuppliers = await client.GetAsync("http://localhost:5288/api/Suppliers");
            string supplierJsonString = await responseSuppliers.Content.ReadAsStringAsync();
            List<SupplierListResponseModel> supList = JsonSerializer.Deserialize<List<SupplierListResponseModel>>(supplierJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            ViewBag.Suppliers = new SelectList(supList, "Id", "CompanyName", "ContactName", "Adress");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = CreateClient();
                StringContent requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5288/api/Products", requestContent);
                if (response.IsSuccessStatusCode) return RedirectToAction("List");
                else return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient client = CreateClient();
            var response = await client.GetAsync("http://localhost:5288/api/Products/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var productModel = JsonSerializer.Deserialize<ProductUpdateRequestModel>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var responseCat = await client.GetAsync("http://localhost:5288/api/Categories");
                if (responseCat.IsSuccessStatusCode)
                {
                    var catJsonString = await responseCat.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<List<CategoryListResponseModel>>(catJsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    ViewBag.Categories = new SelectList(list, "Id", "CategoryName", "Description");

                    await GetSuppliers(client);
                    return View(productModel);
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var client = this.CreateClient();

                var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await client.PutAsync("http://localhost:5099/api/Products", requestContent);

                return RedirectToAction("List");
            }

            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = CreateClient();
            await client.DeleteAsync($"http://localhost:5288/api/Products/{id}");
            return RedirectToAction("List");
        }
    }
}
