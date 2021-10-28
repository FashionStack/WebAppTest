using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GreenStockWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GreenStockWebApp.Pages.Products
{
    public class DetailModel : PageModel
    {
        public Product Product { get; set; }

        string baseUrl = "https://localhost:44309/";
        public async Task<IActionResult> OnDetailsAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Product/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Product = JsonConvert.DeserializeObject<Product>(result);
                }
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("applicaiton/json"));
                HttpResponseMessage response = await client
                    .PutAsJsonAsync("api/Product/" + Product.ProductId, Product);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/.index");
                }
                else
                {
                    return Page();
                }
            }
        }
    }

}
