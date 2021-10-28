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
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; private set; } = new List<Product>();
        string BaseUrl = "https://localhost:44309/";

        public async Task OnGetAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Products");

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Products = JsonConvert.DeserializeObject<List<Product>>(result);
                }
            }

    }
}
}