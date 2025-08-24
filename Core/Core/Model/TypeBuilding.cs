using Core.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class TypeBuilding
    {
        [Key]
        public int Code { get; set; } 
        public string Name { get; set; }
        public eLevel ELevel { get; set; } 
    }
}
