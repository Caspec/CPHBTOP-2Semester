using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ArnaudCore.Models;

namespace ArnaudCore.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<ProductCore> Products { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }
    }
}
