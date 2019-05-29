using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArnaudCore.Data;
using ArnaudCore.Models;

namespace ArnaudCore.Services
{
    public class GarageInitializer
    {
        GarageFactory context;

        public GarageInitializer(GarageFactory context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            context.Database.EnsureCreated();
            if(context.Cars.Any()) { return; }

            context.Cars.Add(new CarCore()
            {
                MaxSpeed = 100,
                Model = "Good old car"
            });
            context.Cars.Add(new CarCore()
            {
                MaxSpeed = 150,
                Model = "Premium car"
            });
            context.Cars.Add(new CarCore()
            {
                MaxSpeed = 190,
                Model = "Luxury car"
            });
            context.SaveChanges();
        }
    }
}
