using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using ArnaudCore.Services;
using ArnaudCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ArnaudCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // ListFileService
            services.AddTransient<IFileStorage, FileStorageService>();

            // GarageFactory service
            services.AddDbContext<GarageFactory>(options => options.UseSqlServer(Configuration.GetConnectionString("CarCoreConnection")));

            // GarageInitializer service
            services.AddTransient<GarageInitializer, GarageInitializer>();

            // ShopDbContext service
            services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductCoreConnection")));

            // ShopInitializer service
            services.AddTransient<IShopInitializer, ShopInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // IShopInitializer parameter added
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IShopInitializer ShopInitializer)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // added for the products in the shop
            ShopInitializer.Initialize();
        }
    }
}
