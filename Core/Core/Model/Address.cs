using Core.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Address
    {
        [Key]
        public int Code { get; set; }
        public Location Location { get; set; }
        public TypeBuilding TypeBuilding { get; set; }
        public bool IsOpen { get; set; } 
        public int BuildingYear { get; set; } 
        public string PersonName { get; set; }
        public string PersonPhone { get; set; } 
        public int SMS { get; set; } 
        public int Capacity { get; set; } 
        public int AmountPeoples { get; set; }
        public DateTime AddDate { get; set; } 
        List<OpinionResource> Opinions; 
    }
}
