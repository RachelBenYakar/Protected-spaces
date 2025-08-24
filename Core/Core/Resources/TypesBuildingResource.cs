using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Resources
{
    public enum eLevel 
    {
        PublicShelter=1,
        Shelter=2,
        ProtectedPublicSpace=3,
        Mamad=4,
        Fortified=5, 
        Stairwell=6
    }
    public class TypesBuildingResource
    {
        public int Code { get; set; } 
        public string Name { get; set; } 
        public eLevel ELevel { get; set; } 
    }
}
