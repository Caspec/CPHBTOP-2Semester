using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ArnaudCore.Models
{
    public class CarCore
    {
        public int ID { set; get; }
        [Required]
        [RegularExpression("..+")]
        public string Model { set; get; }
        [Range(10,300)]
        public double MaxSpeed { set; get; }
    }
}
