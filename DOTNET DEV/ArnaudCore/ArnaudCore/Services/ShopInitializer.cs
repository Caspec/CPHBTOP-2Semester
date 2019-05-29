using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArnaudCore.Data;
using ArnaudCore.Models;

namespace ArnaudCore.Services
{
    public class ShopInitializer : IShopInitializer
    {
        ShopDbContext shopContext;

        public ShopInitializer(ShopDbContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public void Initialize()
        {
            // for updates of db instead of data migrations
            //shopContext.Database.EnsureDeleted();
            shopContext.Database.EnsureCreated();

            if(shopContext.Products.Any())
            {
                return;
            }

            shopContext.Products.Add(new ProductCore()
            {
                Name = "Yoghurt",
                ImageName = "yoghurt.jpg",
                Description = "Its freshness will melt you",
                Price = 3.5M
            });
            shopContext.Products.Add(new ProductCore()
            {
                Name = "Banana",
                ImageName = "banana.jpg",
                Description = "Great for a snack",
                Price = 1.2M
            });
            shopContext.SaveChanges();
        }
    }
}
