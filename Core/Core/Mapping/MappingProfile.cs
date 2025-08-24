using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Core.Resources;

namespace Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
           CreateMap<Address, AddressResource>()
        .ForMember(dest => dest.TypeBuildingCode, opt => opt.MapFrom(src => src.TypeBuilding.Code))
        .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.point1+","+src.Location.point2));

            CreateMap<AddressResource, Address>();
        }
        
    }
}
