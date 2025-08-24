using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Location
    {
        [Key] public int code { get; set; }
        public string Name { get; set; }
        public double point1 { get; set; }
        public double point2 { get; set; }
    }
}
