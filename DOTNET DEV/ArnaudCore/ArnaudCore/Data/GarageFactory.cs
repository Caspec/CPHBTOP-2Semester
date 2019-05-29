using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ArnaudCore.Models;

namespace ArnaudCore.Data
{
    public class GarageFactory : DbContext
    {
        public DbSet<CarCore> Cars { get; set; }

        public GarageFactory(DbContextOptions<GarageFactory> options) : base(options)
        {
        }
    }
}
