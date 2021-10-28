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
    public class CreateModel : PageModel
    {
      [BindProperty]
        public Product Product { get; set; }
        
        string BaseUrl = "https://localhost:44309/";
        public async Task<IActionResult> OnPostAsync ()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/Products", Product);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Product/Index");
                } else
                {
                    return RedirectToPage("./Product/Create");
                }
            }
        }
    }
}
