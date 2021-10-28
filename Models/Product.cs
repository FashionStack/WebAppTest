using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenStockWebApp.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string SKU { get; set; }
        public string Reference_Code { get; set; }
        public int Amount { get; set; }
        public string ImageUrl { get; set; }
        
    }

}
