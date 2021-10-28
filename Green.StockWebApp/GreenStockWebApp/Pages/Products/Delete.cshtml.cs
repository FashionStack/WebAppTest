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
    public class DeleteModel : PageModel
    {
        string BaseUrl = "https://localhost:44309/";

        public Product Product { get; set; }

        public async Task<IActionResult> OnDeleteAsync(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }

            using( var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Products" + id);




                if(response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");

                    
                } else
                {
                    return Page();
                }
          }

            
        }
    }
}
