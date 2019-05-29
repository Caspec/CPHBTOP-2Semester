using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ArnaudCore.ViewModels.Home;
using ArnaudCore.Services;
using ArnaudCore.Data;

namespace ArnaudCore.Controllers
{
    // Core must use Microsoft.EntityFrameworkCore from NuGet
    // Core must use Microsoft.EntityFrameworkCore.SqlServer from NuGet
    // In this case 1.1.6 for Target framework ".NETCoreApp 1.1"


    public class HomeController : Controller
    {
        IFileStorage fileStorage;
        public HomeController(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public IActionResult Index([FromServices] ShopDbContext shopContext, string searchString)
        {
            var products = shopContext.Products
                .Where(p => string.IsNullOrEmpty(searchString) || p.Name.Contains(searchString))
                .OrderBy(p => p.Name)
                .Take(10);
            return View(products);
        }

        public IActionResult Detail([FromServices] ShopDbContext shopContext, int id)
        {
            var found = shopContext.Products.Where(p => p.ID == id).FirstOrDefault();
            return View(found);
        }

        public IActionResult Image([FromServices] ShopDbContext shopContext, int id)
        {
            var found = shopContext
                .Products
                .Where(p => p.ID == id).FirstOrDefault();
            if(found == null)
            {
                return NotFound();
            }
            var filename = string.Format("~/images/{0}", found.ImageName);
            return File(filename, "image/jpeg");
        }

        public IActionResult ComputeProduct(decimal? number1, decimal? number2)
        {
            var viewmodel = new ComputeProductViewModel(number1, number2);
            return View(viewmodel);
        }

        public IActionResult Action1()
        {
            // files sent both by ViewBag and View parameter
            var directory = @"C:\";
            var files = System.IO.Directory.GetFiles(directory);
            ViewBag.Directory = directory;
            ViewBag.FilesList = files;
            return View(files);
        }

        public IActionResult ListFiles()
        {
            var directory = @"C:\";
            var files = System.IO.Directory.GetFiles(directory);
            var vm = new ListFilesViewModel(directory, files);
            return View(vm);
        }

        public IActionResult ListFilesService()
        {
            var directory = @"C:\";
            fileStorage.ChangeDirectory(directory);
            var files = fileStorage.GetCurrentFiles();
            var vm = new ListFilesViewModel(directory, files);
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
