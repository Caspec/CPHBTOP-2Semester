﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArnaudCore.Models
{
    public class ProductCore
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public string ImageName { set; get; }
    }
}
