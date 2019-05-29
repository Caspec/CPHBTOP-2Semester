using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ArnaudCore.Data;
using ArnaudCore.Services;
using ArnaudCore.ViewModels.Garage;

namespace ArnaudCore.Controllers
{
    public class GarageController : Controller
    {
        GarageFactory factory;
        GarageInitializer initializer;

        public GarageController(GarageFactory factory, GarageInitializer initializer)
        {
            this.factory = factory;
            this.initializer = initializer;
        }

        public IActionResult CarsList()
        {
            initializer.Initialize();
            var viewModel = new CarsListViewModel(factory.Cars);
            return View(viewModel);
        }


    }
}
