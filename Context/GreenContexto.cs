using GreenStockWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrenStockWebApi.Context
{
    public class GreenContexto : DbContext
    {
        public GreenContexto(DbContextOptions<GreenContexto> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }


    }
}