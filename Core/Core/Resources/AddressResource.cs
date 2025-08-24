using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Resources
{
    public class AddressResource
    {
        public int Code { get; set; } 
        public int LocationCode { get; set; } 
        public string LocationName { get; set; } 
        public int TypeBuildingCode { get; set; } 
        public bool IsOpen { get; set; } 
        public int BuildingYear { get; set; } 
        public string PersonName { get; set; } 
        public string PersonPhone { get; set;}
        public int SMS { get; set; } 
        public int Capacity { get; set; } 
        public int AmountPeoples { get; set; }
        public DateTime AddDate { get; set; }
        List<OpinionResource> Opinions;
        public double Distance { get; set; }
    }
}
