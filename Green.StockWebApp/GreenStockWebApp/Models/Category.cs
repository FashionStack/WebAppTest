using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenStockWebApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public short SizeTipe { get; set; }
        public List<Product> Product { get; set; }

    }
}
