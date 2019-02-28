using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AMVC.Models
{
    public class ShopFactory : DbContext
    {
       public ShopFactory()
        {
            Database.SetInitializer(new ShopInitializer());
        }

        public DbSet<Product> Products { get; set; }

        public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopFactory>
        {
            protected override void Seed(ShopFactory context)
            {
                context.Products.Add(new Product() { Name = "Youghurt", Description = "This creamy one", Price = 5.4M });
                context.Products.Add(new Product() { Name = "Cleaning", Description = "Very nice cleaning", Price = 64M });
                context.Products.Add(new Product() { Name = "Banana", Description = "Very nice bananana", Price = 3M });
            }
        }
    }


}