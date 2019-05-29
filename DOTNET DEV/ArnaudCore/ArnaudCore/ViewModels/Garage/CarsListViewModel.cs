using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using ArnaudCore.Models;

namespace ArnaudCore.ViewModels.Garage
{
    public class CarsListViewModel
    {
        public IEnumerable<SelectListItem> CarsList { get; private set; }
        public CarCore FastestCar { get; set; }

        public CarsListViewModel(IEnumerable<CarCore> cars)
        {
            CarsList = cars.Select(c => new SelectListItem() { Text = c.Model });
            FastestCar = cars.OrderByDescending(c => c.MaxSpeed).FirstOrDefault();
        }
    }
}
